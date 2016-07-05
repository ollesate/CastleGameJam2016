using UnityEngine;
using System.Collections;

public class RotationLerper : MonoBehaviour {

    public Coroutine LerpTo(Vector3 destination, float duration) {
        StopAllCoroutines();
        return StartCoroutine(
            LerpRotation(transform.rotation, Quaternion.Euler(destination.x, destination.y, destination.z), duration)
            );
    }

    public Coroutine LerpTo(Quaternion destination, float duration) {
        StopAllCoroutines();
        return StartCoroutine(LerpRotation(transform.rotation, destination, duration));
    }

    private IEnumerator LerpRotation(Quaternion src, Quaternion dest, float duration) {
        float startTime = Time.time;
        while (Time.time - startTime < duration) {
            transform.rotation = Quaternion.Lerp(src, dest, (Time.time - startTime) / duration);
            yield return null;
        }
        transform.rotation = dest;
    }
}

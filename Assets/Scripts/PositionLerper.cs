using UnityEngine;
using System.Collections;

public class PositionLerper : MonoBehaviour {

    public Coroutine LerpTo(Vector3 destination, float duration) {
        StopAllCoroutines();
        return StartCoroutine(LerpPosition(transform.position, destination, duration));
    }

    private IEnumerator LerpPosition(Vector3 src, Vector3 dest, float duration) {
        float startTime = Time.time;
        while (Time.time - startTime < duration) {
            transform.position = Vector3.Lerp(src, dest, (Time.time - startTime) / duration);
            yield return null;
        }
        transform.position = dest;
    }
}

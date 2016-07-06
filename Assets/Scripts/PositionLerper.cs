using UnityEngine;
using System.Collections;

public class PositionLerper : MonoBehaviour {

    public Coroutine LerpTo(Vector3 destination, float duration) {
        StopAllCoroutines();
        return StartCoroutine(LerpPosition(transform.position, destination, duration));
    }

    private IEnumerator LerpPosition(Vector3 src, Vector3 dest, float duration) {
        float startTime = Time.time;
        Time.timeScale = 0.1f;
        while (Time.time - startTime < duration) {
            transform.position = Vector3.Lerp(src, dest, (Time.time - startTime) / duration);
            yield return null;
        }
        Time.timeScale = 1f;
        transform.position = dest;
    }
}

using UnityEngine;
using System.Collections;

public class MoveToSequence : MonoBehaviour {

    public Transform[] targetPoints;
    private bool animComplete;

    public bool isFinished;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartSequence());
	}

    IEnumerator StartSequence() {
        foreach (Transform t in targetPoints) {
            StartCoroutine(StartAnimation(t));
            animComplete = false;
            yield return new WaitUntil(isAnimationComplete);
        }
        isFinished = true;
    }

    bool isAnimationComplete() {
        return animComplete;
    }

    IEnumerator StartAnimation(Transform t) {
        float lerpTime = 1f;
        float waitTime = 3f;
        
        Vector3 startPos = transform.position;

        yield return new WaitForSeconds(waitTime);
        float startTime = Time.time;

        while (Time.time - startTime < lerpTime) {
            yield return null;
            transform.position = Vector3.Lerp(startPos, t.position, (Time.time - startTime) / lerpTime);
        }

        transform.position = t.position;

        
        animComplete = true;
    }
}

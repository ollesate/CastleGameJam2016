using UnityEngine;
using System.Collections;
using System;

public class WorldRotator : MonoBehaviour {

    private bool isTriggered;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Enter");

    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            rotatePlayer(collider.gameObject);
        } else if (collider.gameObject.tag == "deathwall") {
            rotateDeathWall(collider.gameObject);
        }
    }

    void rotateDeathWall(GameObject go) {
        Debug.Log("On rotate death wall");

        float duration = 1.5f;

        StartCoroutine(stopFor(go.transform, duration));
        StartCoroutine(moveTo(go.transform, transform.position, duration));

        rotateObject(go.transform, duration, () => { });
    }

    void rotatePlayer(GameObject go) {
        if (isTriggered) return;
        Debug.Log("On rotate player");

        float realDuration = 1.5f;

        Time.timeScale = 0.1f;
        isTriggered = true;

        rotateObject(go.transform, realDuration * Time.timeScale, () => {
            Time.timeScale = 1f;
        });
    }

    void rotateObject(Transform transform, float duration, Action action) {
        Vector3 euler = transform.rotation.eulerAngles;
        IEnumerator task = lerpRotation(transform, new Vector3(euler.x, euler.y - 90, euler.z), duration, action);
        StartCoroutine(task);
    }

    IEnumerator lerpRotation(Transform transform, Vector3 euler, float duration, Action onFinished) {
        Quaternion initialRotation = transform.rotation;
        float startTime = Time.time;
        while (Time.time - startTime < duration) {
            transform.rotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(euler), (Time.time - startTime) / duration);
            yield return null;
        }
        onFinished();
        transform.rotation = Quaternion.Euler(euler);
    }

    IEnumerator stopFor(Transform transform, float duration) {
        float startTime = Time.time;
        Vector3 initialPos = transform.position;
        while (Time.time - startTime < duration) {
            transform.position = initialPos;
            yield return null;
        }
    }

    IEnumerator moveTo(Transform transform, Vector3 target, float duration) {
        float startTime = Time.time;
        Vector3 initialPos = transform.position;
        while (Time.time - startTime < duration) {
            transform.position = Vector3.Lerp(transform.position, target, (Time.time - startTime) / duration);
            yield return null;
        }
    }

}

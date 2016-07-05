using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public GameObject target;

    private float xDiff;
    private float yDiff;

	void Start () {
        if (target == null) {
            Debug.LogError("Follow camera has no target!");
            return;
        }

        // Keep the original x and y difference
        xDiff = target.transform.position.x - transform.position.x;
        yDiff = target.transform.position.y - transform.position.y;
    }
	
	void Update () {
	    if (target == null) {
            Debug.LogWarning("Follow camera has no target!");
            return;
        }
        transform.position = new Vector3(target.transform.position.x - xDiff, target.transform.position.y - yDiff, transform.position.z);
	}
}

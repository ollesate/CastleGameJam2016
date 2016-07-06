using UnityEngine;
using System.Collections;

public class KillWhenBelow : MonoBehaviour {

    public float height;

	void Update () {
	    if (transform.position.y < height) {
            gameObject.SendMessage("Killed");
            Destroy(gameObject);
        }
	}
}

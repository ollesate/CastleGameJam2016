using UnityEngine;
using System.Collections;

public class KillWhenBelow : MonoBehaviour {

    public float height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y < height) {
            Destroy(gameObject);
        }
	}
}

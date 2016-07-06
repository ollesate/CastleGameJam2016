using UnityEngine;
using System.Collections;

public class StickX : MonoBehaviour {
    private float diffX;

    public Transform target;

	// Use this for initialization
	void Start () {
        diffX = target.position.x - transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(target.position.x + diffX, transform.position.y, transform.position.z);
    }
}

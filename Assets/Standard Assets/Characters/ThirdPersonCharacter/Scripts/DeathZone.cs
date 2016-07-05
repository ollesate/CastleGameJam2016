using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        Destroy(collision.gameObject);
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider collider) {
        Destroy(collider.gameObject);
        Debug.Log("OnTriggerEnter");
    }
}

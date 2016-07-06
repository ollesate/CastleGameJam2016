using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            Debug.Log("OnCollisionEnter");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            Destroy(collider.gameObject);
            Debug.Log("OnTriggerEnter");
        }
    }
}

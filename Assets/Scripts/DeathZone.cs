using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        Destroy(collision.gameObject);
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider collider) {
        Destroy(collider.gameObject);
        Debug.Log("OnTriggerEnter");
    }
}

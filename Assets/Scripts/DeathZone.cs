using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.SendMessage("Killed");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.SendMessage("Killed");
        }
    }
}

using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            gameObject.SendMessage("Killed");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            gameObject.SendMessage("Killed");
        }
    }
}

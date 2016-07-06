using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float speed = 1.0f;

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        gameObject.transform.position += transform.forward * speed * Time.deltaTime;
    }
}

using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

    public Transform target;
    public float speed = 4f;
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = (target.position - transform.position);
        if (delta.magnitude < speed * Time.deltaTime) return;
        transform.position += delta.normalized * speed * Time.deltaTime;
	}

    void setTarget(Transform target) {
        this.target = target;
    }
}

using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

    public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        gameObject.transform.position = new Vector3(pos.x + speed * Time.deltaTime, pos.y, pos.z);
	}
}

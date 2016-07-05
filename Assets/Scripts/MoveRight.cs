using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

    public float speed = 1.0f;
    private float initialZ;
	// Use this for initialization
	void Start () {
        initialZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        float zSin = Mathf.Sin(Time.time) * 2.0f;

        gameObject.transform.position = new Vector3(pos.x + speed * Time.deltaTime, pos.y, initialZ + zSin);
	}
}

using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    public float speed = 7.0f;
    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        float ySin = Mathf.Sin(Time.time*speed)*0.1f;

        gameObject.transform.position = new Vector3(pos.x, initialY + ySin, pos.z);
	}
}

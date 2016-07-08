using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public Vector3 Speed;
	
	void Update () {
        transform.Rotate(Speed * Time.deltaTime);
	}
}

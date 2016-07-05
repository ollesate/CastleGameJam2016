using UnityEngine;
using System.Collections;

public class platformManager : MonoBehaviour {

	GameObject platform;
	GameObject[] platformArray;
	BoxCollider platformCollider;

	public bool changeDimensions = false;
	// Use this for initialization
	void Start () {
		//Get all platforms
	}

	// Update is called once per frame
	void Update () {
		if(changeDimensions) {
			changeDimensions = false;
			foreach (GameObject platform in platformArray) {
				//platform.GetComponent<PlatformScript>.changeDimensions ();
			}
		}
	}




}

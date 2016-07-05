using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	GameObject[] platformArray;
	public bool enabled3d = true;

	// Use this for initialization
	void Start () {
		//Get all platforms
		platformArray = GameObject.FindGameObjectsWithTag("platform");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			ChangeDimensions (true);
			enabled3d = true;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			ChangeDimensions (false);
			enabled3d = false;
		}
	}

	void ChangeDimensions (bool is3d) {
		enabled3d = is3d;
		foreach (GameObject platform in platformArray) {
			platform.GetComponent<PlatformScript>().ChangeDimension(is3d);
		}
	}




}

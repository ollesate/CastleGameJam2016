using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	GameObject[] platformArray;
	public bool enabled3d = true;
	public bool changeDimensions = false;

	// Use this for initialization
	void Start () {
		//Get all platforms
		platformArray = GameObject.FindGameObjectsWithTag("platform");

	}

	// Update is called once per frame
	void Update () {
		if(changeDimensions) {
			enabled3d = !enabled3d;
			changeDimensions = false;
			foreach (GameObject platform in platformArray) {
				platform.GetComponent<PlatformScript>().ChangeDimension(enabled3d);
			}
		}
	}




}

using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	public bool enabled3d = true;

	// Use this for initialization
	void Start () {

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
        PlatformScript[] platformArray = GetComponentsInChildren<PlatformScript>();
		foreach (PlatformScript platform in platformArray) {
			platform.ChangeDimension(is3d);
		}
	}

}

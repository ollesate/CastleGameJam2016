using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	public void ChangeDimensions (bool is3d) {
        Debug.Log("Platform manager change dimension to " + (is3d ? "3d" : "2d"));
        PlatformScript[] platformArray = GetComponentsInChildren<PlatformScript>();
		foreach (PlatformScript platform in platformArray) {
			platform.ChangeDimension(is3d);
		}

	}

}

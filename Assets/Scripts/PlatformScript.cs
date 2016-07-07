﻿using UnityEngine;
using System.Collections;


/* GameObject with platformscript should have the tag "platform"
 * It needs at least 3 box colliders (may be changed?) for it to work.
 * 
 * Collider 1: Should be the ordinary 3d size. Should cover the visual representation.
 * Collider 2: Should cover the whole 3d space, used in 2d mode.
 * Collider 3: Should be smaller Y size than collider 2, used to detect if player should be killed. Should be a trigger.
 * 
 */
public class PlatformScript : MonoBehaviour {

	GameObject platform;
	Collider[] platformColliders;

	// Use this for initialization
	void Awake () {
		platform = this.gameObject;
		platformColliders = platform.GetComponents<Collider>();
	}

	public void ChangeDimension(bool is3d){
		for (int i = 1; i < platformColliders.Length; i++) {
			platformColliders [i].enabled = !is3d;
		}
	}

		


}

using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	GameObject platform;
	BoxCollider[] platformColliders;

	// Use this for initialization
	void Start () {
		platform = this.gameObject;
		platformColliders = platform.GetComponents<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	} //TODO: Remove update so it's not heavy? Check it up

	public void ChangeDimension(bool enabled){
		if (platformColliders.Length < 2) {
			Debug.LogError("The GameObject has not enough box colliders, it needs at least 2 to be a legit plattform.");
			return;
		}
		platformColliders[1].enabled = enabled;
		//TODO: if enabled && player.x&y is colliding with platform.x&y then player.kill 
	}


}

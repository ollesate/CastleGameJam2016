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
		platformColliders[1].enabled = enabled;
	}


}

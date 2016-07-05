using UnityEngine;
using System.Collections;

public class PlattformScript : MonoBehaviour {

	GameObject plattform;
	BoxCollider plattformCollider;


	// Use this for initialization
	void Start () {
		plattform = this.gameObject;
		plattformCollider = plattform.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	} //TODO: Remove update so it's not heavy? Check it up

	void changeDimension(){
		
	}


}

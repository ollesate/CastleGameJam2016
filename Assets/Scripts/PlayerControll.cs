using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerControll : MonoBehaviour {
	public float speed = 4.0f;
	private float xSpeed, zSpeed;

	public float jump = 3.0F;

	public float airSpeedAcceleration = 0.1F;

	public float maxAirSpeed = 3.0F;
	private float xMaxAirSpeed, zMaxAirSpeed;

	public float gravity = 10.0F;
	private float zModifier = 1.0F;
	//public float rotateSpeed = 3.0F;
	private Vector3 moveDirection = Vector3.zero;

	private CharacterController controller;

	// Use this for initialization
	void Start () {
		xSpeed = speed;
		xMaxAirSpeed = maxAirSpeed;
		zSpeed = speed-zModifier;
		zMaxAirSpeed = maxAirSpeed-zModifier;
		controller = GetComponent<CharacterController> ();
	}
		
	// Update is called once per frame
	void Update () {
		
		float xInputAxis = (Input.GetAxis ("Horizontal"));
		float zInputAxis = Globals.Is3D ? Input.GetAxis ("Vertical") : 0f;

		if (controller.isGrounded) {
			moveDirection = new Vector3 (xInputAxis, 0, zInputAxis);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection.x *= xSpeed;
			moveDirection.z *= zSpeed;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jump;
			}
		} else {
			float tempY = moveDirection.y; // probably not needed, haven't tried to fix this (saves it before modification, adds it again after)

			float moveX = moveDirection.x;
			float moveZ = moveDirection.z;

			// Adds speed to maximum of MaxAirSpeed to the player if the player is in the air.
			if ((moveDirection.x + xInputAxis <= xMaxAirSpeed || xInputAxis<0) && (moveDirection.x - xInputAxis >= -xMaxAirSpeed || xInputAxis>0)) {
				moveX += xInputAxis * airSpeedAcceleration;
			}

			if ((moveDirection.z + zInputAxis <= zMaxAirSpeed || zInputAxis<0) && (moveDirection.z - zInputAxis >= -zMaxAirSpeed || zInputAxis>0)) {
				moveZ += zInputAxis * airSpeedAcceleration;
			}

			moveDirection = new Vector3 (moveX, 0, moveZ);

			moveDirection = transform.TransformDirection (moveDirection);
			//moveDirection *= speed;
			moveDirection.y = tempY;
		}

		//Rotation towards vector direction


		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

	}


	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("test3");
		if(col.gameObject.tag == "platform")
		{
			//Set Death animation
			Debug.Log("test");
			Destroy(this.gameObject, 0); //TODO: Change to 2 when there's a death anim
			//Game end
		}
	}




} 


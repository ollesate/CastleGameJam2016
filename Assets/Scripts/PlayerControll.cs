﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

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
    private Animator animator;

	private bool is3d = true;
	private Transform lastTouched=null;
    private bool canControlCharacter = true;
    private bool justJumped = false;

    private float jumpCooldown = 0.1f;
    private float jumpTimer;
	// Use this for initialization
	void Start () {
		xSpeed = speed;
		xMaxAirSpeed = maxAirSpeed;
		zSpeed = speed-zModifier;
		zMaxAirSpeed = maxAirSpeed-zModifier;
		controller = GetComponent<CharacterController> ();
        //Animation
        animator = GetComponent<Animator>();
	}

    public void CanControlCharacter(bool canControl)
    {
        canControlCharacter = canControl;
    }

	// Update is called once per frame
	void Update () {

        float xInputAxis = 0f;
        float zInputAxis = 0f;
        justJumped = false;
        if (canControlCharacter) { 
		    xInputAxis = (Input.GetAxis ("Horizontal"));
		    zInputAxis = Globals.Is3D ? Input.GetAxis ("Vertical") : 0f;
        }



		if (controller.isGrounded) {
			moveDirection = new Vector3 (xInputAxis, 0, zInputAxis);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection.x *= xSpeed;
			moveDirection.z *= zSpeed;
            jumpTimer += Time.deltaTime;
            
            
			if (Input.GetButtonDown ("Jump")) {
				if (jumpTimer > jumpCooldown) {
					jumpTimer = 0;
					if (canControlCharacter) {
						moveDirection.y = jump;
						justJumped = true;
					}
				}
			} 
		} else {
			if (Input.GetButtonUp ("Jump")) {
				if (controller.velocity.y > 0){
					Debug.Log ("moveDirection.y before: " + moveDirection.y);
					moveDirection.y = (float) (controller.velocity.y * 0.5);
					Debug.Log ("moveDirection.y after: " + moveDirection.y);
				}
			}
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
		float speedMagnitude = new Vector3 (controller.velocity.x/xSpeed, 0, controller.velocity.z/zSpeed).magnitude;
		animator.SetFloat("Speed", speedMagnitude);
		//Debug.Log (speedMagnitude);

		//Rotation towards vector direction


		moveDirection.y -= gravity * Time.deltaTime;

		if (Math.Abs (moveDirection.x) > 0.1 || Math.Abs (moveDirection.z) > 0.1) {
			gameObject.transform.GetChild (0).rotation = Quaternion.LookRotation (new Vector3 (-moveDirection.x, 0, -moveDirection.z).normalized);
		}
		controller.Move (moveDirection * Time.deltaTime);

        if (justJumped == true)
        {
            animator.SetBool("Jumped", true);
        }
        else
        {
            animator.SetBool("Jumped", false);
        }

        if (controller.isGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }

    }

	public void ChangeDimensions(bool is3d){
		this.is3d = is3d;
		if (lastTouched && controller.isGrounded && is3d) {
			controller.Move (new Vector3 (0, 0, lastTouched.position.z - controller.transform.position.z));
		}
	}

	void OnControllerColliderHit(ControllerColliderHit platform){
		if (platform.gameObject.tag == "platform") {
			lastTouched = platform.transform;
		}
	}


	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "platform" || col.gameObject.tag == "spike")
		{
            Debug.Log("Player died because of a " + col.gameObject.tag + "collision");
            gameObject.SendMessage("Killed");
		}
	}

	public bool canControl(){
		return canControlCharacter;
	}
} 
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Public
	public Rigidbody playerRigidBody;

	// Player
	private string playerControlScheme;
	private float playerForwardSpeed;
	private float playerRotateSpeed;
	private float playerJumpSpeed;
	
	private float playerMaxSpeed;
	private bool playerOnGround;
	private bool playerJumping;

	private Vector3 newVelocity;

	private int playerNumberOfCollisions;

	// Use this for initialization
	void Start () {
		// Controls
		playerControlScheme = "Keyboard";
		playerForwardSpeed = 25f;
		playerRotateSpeed = 2f;
		playerJumpSpeed = 500f;
		playerJumping = false;
		playerOnGround = false;
		playerMaxSpeed = 25f;
		playerNumberOfCollisions = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//print(playerRigidBody.velocity.magnitude);
		if (playerRigidBody.velocity.magnitude >= 25f) {
			Vector3 newVelocity = playerRigidBody.velocity.normalized;
			newVelocity = newVelocity * playerMaxSpeed;
			playerRigidBody.velocity = newVelocity;
		}
		if (playerControlScheme == "Keyboard") {
			controls_player1_keyboard ();
		} else if  (playerControlScheme == "Controller") {
			controls_player1_xbox ();
		}
	}

	void controls_player1_xbox () {
		if (Input.GetAxis ("Player1_LeftHorizontal") < 0) { // Left axis turn left

		} else {
			
		}
		if (Input.GetAxis ("Player1_LeftHorizontal") > 0) { // Left axis turn right
			
		} else {
			
		}
		if (Input.GetAxis ("Player1_LeftVertical") < 0) { // Left axis acceleration
			
		} else {
			
		}
		if (Input.GetAxis ("Player1_RightVertical") != 0) { // Right axis zoom controls
			
		} 
		if (Input.GetAxis ("Player1_TriggerR") > 0) { // Right trigger acceleration
			
		} else {
			
		}

		if (Input.GetButton ("Player1_ButtonA")) {

		}
		if (Input.GetButton ("Player1_ButtonB")) {

		}
		if (Input.GetButton ("Player1_ButtonX")) {

		}
		if (Input.GetButton ("Player1_ButtonY")) {

		}
		if (Input.GetButton("Player1_ButtonThumbStickRight")) {
			
		}
	}

	void controls_player1_keyboard () {
		if (Input.GetKey ("w") && !playerJumping) { // Forward
			playerRigidBody.AddRelativeForce (Vector3.forward * playerForwardSpeed);
		}
		if (Input.GetKey ("s")) { // Back
			playerRigidBody.AddRelativeForce (Vector3.back * (playerForwardSpeed / 2));
		}
		if (Input.GetKey ("a")) { // Left
			this.transform.Rotate (Vector3.down * playerRotateSpeed);
		}
		if (Input.GetKey ("d")) { // Right
			this.transform.Rotate (Vector3.up * playerRotateSpeed);
		}
		if (Input.GetKey ("space") && !playerJumping && playerNumberOfCollisions > 0) { // jump
			playerRigidBody.AddRelativeForce (Vector3.up * playerJumpSpeed);
			playerJumping = true; // Disable in onCollisionEnter method
			playerOnGround = false;
		}
		if (Input.GetKey ("right")) {

		} else {
			
		}
		if (Input.GetKey ("left")) {
			
		} else {
			
		}
		if (Input.GetKey ("up")) {
			
		} else {
			
		}
		if (Input.GetKey ("down")) {
			
		}
		if (Input.GetKey("left shift")) { 
			
		} else {
			
		}
		if (Input.GetKey("left ctrl")) { 
			
		} else {
			
		}
		if (Input.GetKey ("q")) {
			
		}
		if (Input.GetKey ("e")) {
			
		}
	}

	void OnCollisionEnter (Collision col) {
        if(col.gameObject.tag == "Ground") {
            playerJumping = false;
			playerOnGround = true;
        } else if (col.gameObject.tag == "Arson") {
			col.gameObject.GetComponent<Rigidbody>().AddRelativeForce (Vector3.up * (playerRigidBody.velocity.magnitude / 2));
			// Make player lose control when taking dmg
			playerRigidBody.AddRelativeForce (Vector3.up * playerJumpSpeed / 2);
			playerJumping = true; // Disable in onCollisionEnter method
			playerOnGround = false;
			print(playerRigidBody.velocity);
			playerRigidBody.velocity = Vector3.Reflect(playerRigidBody.velocity, Vector3.forward);
		}
		playerNumberOfCollisions +=1;
    }

	void OnCollisionStay (Collision col) {
		if (col.gameObject.tag == "Building" && playerRigidBody.velocity.magnitude == 0f) {
			playerJumping = false;
			playerOnGround = true;
		}
	}

	void OnCollisionExit (Collision col) {
		playerNumberOfCollisions -=1;
		if (playerNumberOfCollisions <= 0) {
			playerOnGround = false;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

	private bool humanOnGround;
	private float humanWalkTimer;
	private float currentTime;
	public Rigidbody humanRigidBody;
	private float humanForwardSpeed;
	private float humanMaxSpeed;
	private float humanRotateSpeed;

	// Use this for initialization
	void Start () {
		humanOnGround = false;
		humanMaxSpeed = 3f;
		humanForwardSpeed = 2f;
		humanWalkTimer = 2f;
		humanRotateSpeed = 50f;
		currentTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (humanOnGround) {
			if (currentTime >= humanWalkTimer) {
				currentTime = 0f;
				ChangeDirection();
			}
			if (humanRigidBody.velocity.magnitude >= humanMaxSpeed) {
				Vector3 newVelocity = humanRigidBody.velocity.normalized;
				newVelocity = newVelocity * humanMaxSpeed;
				humanRigidBody.velocity = newVelocity;
			}
			Walk();		
		}
	}

	void Walk() {
		humanRigidBody.AddRelativeForce (Vector3.forward * humanForwardSpeed);
	}

	public void Grounded() {
		humanOnGround = true;
	}

	public void ChangeDirection() {
		float randomNumber = Random.Range(0.0f,2.0f);
		if (randomNumber >=1.0f) { //left
			this.transform.Rotate (Vector3.down * humanRotateSpeed);
		} else { //right
			this.transform.Rotate (Vector3.up * humanRotateSpeed);
		}
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Human" || col.gameObject.tag == "Arson" || col.gameObject.tag == "Building") {
			humanOnGround = true;
		} 
	}

	void OnCollisionExit(Collision col) {
		if(col.gameObject.tag == "Ground") {
			humanOnGround = false;
		}
	}
}

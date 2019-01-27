using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleGrabber : MonoBehaviour {

	public WereHouse playerWereHouse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Human") {
			print(col.gameObject.name);
			playerWereHouse.AddPerson(); // playerPeopleCount += 1;
			Destroy(col.gameObject);
		}
	}
}

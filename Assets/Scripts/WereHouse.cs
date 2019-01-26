using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereHouse : MonoBehaviour {

	public int playerPeopleCount;
	public GameObject prefabHuman;
	private GameObject humanSpawn;
	private Vector3 pos;
	private Rigidbody humanSpawnRigidbody;

	// Use this for initialization
	void Start () {
		playerPeopleCount = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropPeople (Vector3 dropVelocity) {
		playerPeopleCount -= 1;
		if (playerPeopleCount <= 0) {
			print("GameOver");
		}
		pos = this.gameObject.transform.position;
		humanSpawn = (GameObject) Instantiate(prefabHuman, new Vector3(pos.x, pos.y + 2, pos.z), Quaternion.identity);
		humanSpawnRigidbody = humanSpawn.GetComponent<Rigidbody>();
		humanSpawnRigidbody.velocity = dropVelocity;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WereHouse : MonoBehaviour {

	private GameController gameController;
	public Text ui_people;
	public Text ui_ghosts;
	public Text ui_timer;

	public int playerPeopleCount;
	public int ghostPeopleCount;
	public GameObject prefabHuman;
	private GameObject humanSpawn;
	private Vector3 pos;
	private Rigidbody humanSpawnRigidbody;

	// Timer end game
	private float timer;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		playerPeopleCount = gameController.GetPeople();
		ghostPeopleCount = gameController.GetGhosts();
		ui_people.text = playerPeopleCount.ToString();
		ui_ghosts.text = ghostPeopleCount.ToString();
		timer = 30f;
		ui_timer.text = Mathf.RoundToInt(timer).ToString();
	}
	
	public void AddPerson() {
		playerPeopleCount += 1;
		gameController.AddPerson();
		ui_people.text = playerPeopleCount.ToString();
	}

	public void RemovePerson() {
		playerPeopleCount -= 1;
		ghostPeopleCount += 1;
		gameController.AddGhost();
		gameController.RemovePerson();
		ui_people.text = playerPeopleCount.ToString();
		ui_ghosts.text = ghostPeopleCount.ToString();
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		ui_timer.text = Mathf.RoundToInt(timer).ToString();
		if (timer <= 0) {
			gameController.StartSceneGameOver();
		}
	}

	public void DropPeople (Vector3 dropVelocity) {
		RemovePerson();
		if (playerPeopleCount <= 0) {
			print("GameOver");
			gameController.StartSceneGameOver();
		}
		pos = this.gameObject.transform.position;
		humanSpawn = (GameObject) Instantiate(prefabHuman, new Vector3(pos.x, pos.y + 2, pos.z), Quaternion.identity);
		humanSpawnRigidbody = humanSpawn.GetComponent<Rigidbody>();
		humanSpawnRigidbody.velocity = dropVelocity;
	}
}

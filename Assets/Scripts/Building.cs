using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	
	private float humanSpawnTimer;
	private float currentTime;
	private Vector3 pos;
	public GameObject prefabHuman;
	public GameObject prefabArson;
	private GameObject humanSpawn;
	private GameController gameController;


	// Use this for initialization
	void Start () {
		currentTime = 0f;
		humanSpawnTimer = Random.Range(1f, 5f);
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= humanSpawnTimer && gameController.numberOfPeople < gameController.maxPeople) {
			pos = this.gameObject.transform.position;
			float arson = Random.Range(0.0f, 4.0f);
			if (arson >= 3f) {
				humanSpawn = (GameObject) Instantiate(prefabArson, new Vector3(pos.x + 2, pos.y, pos.z), Quaternion.identity);
				gameController.numberOfPeople += 1;
			} else {
				humanSpawn = (GameObject) Instantiate(prefabHuman, new Vector3(pos.x + 2, pos.y, pos.z), Quaternion.identity);
				humanSpawn.GetComponent<Human>().ChangeDirection();
				gameController.numberOfPeople += 1;
			}
			currentTime = 0f;
		}
	}
}

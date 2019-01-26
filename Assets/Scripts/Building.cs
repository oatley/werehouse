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


	// Use this for initialization
	void Start () {
		currentTime = 0f;
		humanSpawnTimer = Random.Range(5f, 15f);
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= humanSpawnTimer) {
			pos = this.gameObject.transform.position;
			float arson = Random.Range(0.0f, 4.0f);
			if (arson >= 3f) {
				humanSpawn = (GameObject) Instantiate(prefabArson, new Vector3(pos.x + 2, pos.y, pos.z), Quaternion.identity);
			} else {
				humanSpawn = (GameObject) Instantiate(prefabHuman, new Vector3(pos.x + 2, pos.y, pos.z), Quaternion.identity);
				humanSpawn.GetComponent<Human>().ChangeDirection();
			}
			currentTime = 0f;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.gameObject.transform.position;
		humanSpawn = (GameObject) Instantiate(prefabHuman, new Vector3(pos.x, pos.y + 2, pos.z), Quaternion.identity);
	}
}

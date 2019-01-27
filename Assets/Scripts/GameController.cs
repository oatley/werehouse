using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private int people;
	private int ghosts;
	private int score;
	public int maxPeople;
	public int numberOfPeople;

	public void AddPerson() {
		people += 1;
	}

	public void RemovePerson() {
		people -= 1;
	}

	public void AddGhost() {
		ghosts += 1;
	}

	public int GetPeople() {
		return people;
	}

	public int GetGhosts() {
		return ghosts;
	}

	public int GetScore() {
		score = (people * 5) - (ghosts - 2);
		return score;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		ResetGame();
		maxPeople = 200;
	}
	
	public void ResetGame () {
		people = 3;
		ghosts = 0;
		score = 0;
		numberOfPeople = 0;
	}

	public void StartSceneMainGame() {
		SceneManager.LoadScene("MainGame");
	}

	public void StartSceneGameOver() {
		SceneManager.LoadScene("GameOver");
	}

	public void Quit() {
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	public GameObject ui_highScore;

	private GameController gameController;
	private int int_score;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		int_score = gameController.GetScore();
		ui_highScore.GetComponent<Text>().text = int_score.ToString();
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

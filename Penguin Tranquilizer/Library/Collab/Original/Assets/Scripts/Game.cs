using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public GameObject gameOverPanel;

	public GameUI gameUI;
	public GameObject player;
	public bool isGameOver;

	private static Game singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
		isGameOver = false;
		Time.timeScale = 1;

	}


	public void OnGUI() {
		if(isGameOver && Cursor.visible == false) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void GameOver() {
		isGameOver = true;
		Time.timeScale = 0;
		//player.GetComponent<FirstPersonController> ().enabled = false;
		//player.GetComponent<CharacterController> ().enabled = false;
		gameOverPanel.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene (Constants.SceneBattle);
		gameOverPanel.SetActive (true);
	}

	public void Exit() {
		Application.Quit();
	}

	public void MainMenu() {
		SceneManager.LoadScene (Constants.SceneMenu);
	}
}

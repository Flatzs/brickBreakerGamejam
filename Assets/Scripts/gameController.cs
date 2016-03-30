using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	public GameObject restartButton;
	public GameObject shadeLayer;
	public GameObject gameOverText;
	public GameObject startGameText;
	public GameObject player;
	public GameObject scoreText;
	public GameObject endGameScoreText;

	private int score= 0;

	// Use this for initialization
	void Start () {
		shadeLayer.SetActive (true);
		startGameText.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EndGame(){

		player.SendMessage ("dead");
		restartButton.SetActive (true);
		shadeLayer.SetActive (true);
		gameOverText.SetActive (true);
		endGameScoreText.GetComponent<TextMesh> ().text = "You harvested " + score + " spood!";

	}

	void startGame(){

		shadeLayer.SetActive (false);
		player.SendMessage ("start");
		GameObject.Find ("Ball").SendMessage ("startGame");
		startGameText.SetActive (false);
		shadeLayer.SetActive (false);


	}

	void addScore(){
		score++;
		scoreText.GetComponent<TextMesh> ().text = score.ToString ();
	}
}

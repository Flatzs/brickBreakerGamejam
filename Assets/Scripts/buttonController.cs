using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (this.gameObject.name == "restart_button") {

			SceneManager.LoadScene ("Game");
		} else if (this.gameObject.name == "start_button") {
			GameObject.Find ("gameController").SendMessage ("startGame");
			this.gameObject.SetActive (false);
		}

	}
	void OnMouseDown(){



	}
}

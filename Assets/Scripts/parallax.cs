using UnityEngine;
using System.Collections;

public class parallax : MonoBehaviour {

	Transform player;


	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3( (transform.position.x - player.position.x) * 0.01f, 
		                             transform.position.y,
		                             transform.position.z);
	
	}
}

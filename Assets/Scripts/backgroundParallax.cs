//****************************************************
// backgroundParallax.cs
//
// This script controls the background parallaxing effect
// for the game Splocky. Attach all background sprites to
// the Transform array.
// 
// Gage Langdon
//
// Copyright(c) 2016 gagelangdon@gmail.com
//¯\_(⊙_ʖ⊙)_/¯	¯\_(⊙_ʖ⊙)_/¯	¯\_(⊙_ʖ⊙)_/¯	¯\_(⊙_ʖ⊙)_/¯


using UnityEngine;
using System.Collections;

public class backgroundParallax : MonoBehaviour {

	public 	Transform[] backgrounds;
	public 	float 		parallaxScale;
	public 	float 		parallaxReductionFactor;
	public	float 		smoothing;

	private	Transform 	cam;
	private Vector3 	previousCamPos;
	private float 		parallax;
	private Transform   playerPos;

	void Awake()
	{
		cam = Camera.main.transform; //Main Camera 
		playerPos = GameObject.Find ("Player").transform;


	}// </Awake>


	void Start () {
		previousCamPos = cam.position; 

		StartCoroutine (Parallax());
	}// </Start>
	

	IEnumerator Parallax(){

		while (true) {

			if (playerPos && playerPos.position.y > 500){
				smoothing = smoothing * 2;

			}
			// The parallax is the opposite of teh camera movement
			parallax = (previousCamPos.y - cam.position.y) * parallaxScale;
		
			// For each background.. PARALLAX THAT SHIT
			for (int i = 0; i < backgrounds.Length; i++) {
				if (backgrounds[i]){
					// Calculate target y-coordinate
					float backgroundTargetPosx = backgrounds [i].position.x + parallax * (i * parallaxReductionFactor + 1);
					// New target position
					Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosx, backgrounds [i].position.y, backgrounds [i].position.z);
					// Lerp from current to the new target position
					backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backgroundTargetPos, smoothing * Time.deltaTime);
				}
			}
		
			previousCamPos = cam.position;

			yield return new WaitForSeconds(0.01f);
		}

	}// </Parallax>

}// </class backgroundParallax>

/// <summary>
/// Ball.cs
/// 
/// Gage Langdon
/// 3.24.2016
/// 
/// </summary>

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    // ball movement speed
    public float ballSpeed = 100.0f;
	public float maxBallSpeed = 300f;
	public float maxVelocity = 1f;
	private Rigidbody2D rb2d ;
	private Vector3 dir;
	private Transform mainCam;
	public AudioSource shieldSound;

    
	void Start(){

		mainCam = Camera.main.transform;
		rb2d = GetComponent<Rigidbody2D> ();
	}

    void startGame()
    {


        // Get the ball's rigid body
        rb2d.velocity = Vector2.up * ballSpeed;

		rb2d.AddTorque(1f);
    }

    
    float ballAngle(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
       
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    
   void OnCollisionEnter2D(Collision2D collision)
    {
		
        
		if (collision.gameObject.name == "Player") {

			if (this.transform.position.y < collision.transform.position.y) {
				GameObject.Find ("gameController").SendMessage ("EndGame");
				rb2d.velocity = new Vector2 (0f, 0f);
				rb2d.AddTorque (-1f);
				rb2d.isKinematic = true;
			}


			// Calculate the angle.
			shieldSound.Play();
			float x = ballAngle (transform.position, collision.transform.position, collision.collider.bounds.size.x);

			// Normalize that shit.
			dir = new Vector2 (x, 1).normalized;

			// Calculate Velocity.
			rb2d.velocity = dir * ballSpeed;




			if (ballSpeed < maxBallSpeed)
				ballSpeed += 10f;
		} 
		if (collision.gameObject.name == "borderBottom" || collision.gameObject.name == "guy") {
			GameObject.Find ("gameController").SendMessage ("EndGame");
			rb2d.velocity = new Vector2 (0f, 0f);
			rb2d.AddTorque (-1f);
			//GetComponent<BoxCollider2D> ().enabled = false;
		
			//Destroy (this.gameObject);
		}
		else 
			mainCam.SendMessage ("shakeScreen");
    }

	void Update(){
		//Debug.Log(rb2d.velocity);
		rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity , maxVelocity);
	}

    
}

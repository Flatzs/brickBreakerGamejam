using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Paddle : MonoBehaviour {

    //this is the movement speed of the paddle

    public float runningSpeed = 150;
	public float sprintingSpeed = 300;
	private float speed = 150;
	public Animator guyAnim;

    //this creates a reference to the rigidbody on the paddle
    public Rigidbody2D rb2d;

	private bool facingLeft  = false;
	private bool isRunning	 = false;
	private bool isSliding 	 = false;

	// sliding vars
	public float slideTimerMax = 0.15f;
	private float slideTimer = 0f;
	private Vector3 slideForward;


	private bool isDead = false;
	private bool isGameStarted = false;

	void Start(){
		rb2d = this.GetComponent<Rigidbody2D>();
	}


    //this runs every frame. even if their computer is slower or fasted this will run the same speed.
    void Update()
    {

		if (!isDead && isGameStarted) {

			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = sprintingSpeed;
			} else {	
				speed = runningSpeed;
			}

			// jump
//		if (Input.GetKeyDown(KeyCode.Space)){
//			Debug.Log("jump");
//			rb2d.AddForce(Vector2.up * 20000);
//		}



			//get horizontal movement from axis
			float hor = Input.GetAxisRaw ("Horizontal");

			// Set Velocity (movement direction * speed)
			rb2d.velocity = Vector2.right * hor * speed;

		}

    }

	void FixedUpdate(){

		if (!isDead && isGameStarted) {

			// Sprite direction
			if (Input.GetKey (KeyCode.D)) {
				guyAnim.SetBool ("running", true);
				isRunning = true;
				slideForward = transform.right;

				if (facingLeft) {
					guyAnim.transform.localScale = new Vector3 (-guyAnim.transform.localScale.x,
						guyAnim.transform.localScale.y,
						guyAnim.transform.localScale.z);
					//guyAnim.transform.Rotate(new Vector3(0f,180f,0f));
					facingLeft = false;


				}
			} else if (Input.GetKey (KeyCode.A)) {
				guyAnim.SetBool ("running", true);
				isRunning = true;
				slideForward = transform.right * -1;

				if (!facingLeft) {
					guyAnim.transform.localScale = new Vector3 (-guyAnim.transform.localScale.x,
						guyAnim.transform.localScale.y,
						guyAnim.transform.localScale.z);
					facingLeft = true;

				}

			} else if (isRunning) {

		
				// ANIMATION: running => slide => idle
				guyAnim.SetBool ("running", false);

				// push the guy a little further to "slide"
				if (speed == sprintingSpeed)
					isSliding = true;

				isRunning = false;

			}


			if (isSliding) {
				Debug.Log ("sliding");

				rb2d.velocity = slideForward * runningSpeed;

				slideTimer += Time.deltaTime;
				if (slideTimer > slideTimerMax) {
					isSliding = false;
					slideTimer = 0;
					//isRunning = false;
				}


			}




		}
	}

	void dead(){
		isDead = true;
	}

	void start(){
		isGameStarted = true;
	}
}

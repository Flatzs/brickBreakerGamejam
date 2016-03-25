using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    //this is the movement speed of the paddle
    public float movementSpeed = 150;
	public Animator guyAnim;

    //this creates a reference to the rigidbody on the paddle
    public Rigidbody2D rb2d;

    //this runs every frame. even if their computer is slower or fasted this will run the same speed.
    void FixedUpdate()
    {

        //get horizontal movement from axis
        float hor = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        rb2d.velocity = Vector2.right * hor * movementSpeed;
    }

	void Update(){

		if(rb2d.velocity.x > 0f){
			guyAnim.SetBool("running",true);
			//guyAnim.transform.rotation = new Vector3(0f,0,0f);
		}
		else if (rb2d.velocity.x < 0f){
			guyAnim.SetBool("running",true);

			if (guyAnim.transform.rotation.y != 180.0f){
				guyAnim.transform.Rotate(new Vector3(0f,180f,0f));
			}

		}
		else if (rb2d.velocity.x == 0f){
			guyAnim.SetBool("running",false);
		}

	}
}

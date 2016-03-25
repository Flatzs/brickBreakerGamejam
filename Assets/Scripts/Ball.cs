using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    //set the movement speed of the ball
    public float ballSpeed = 100.0f;

    //this runs as soon as the scene starts
    void Start()
    {
        //this sets the rigidbody of the ball to the ball speed on start, then once set it stays set.
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }

    //this is a custom function to determine how far along the ball hit the paddle
    //it works by taking the ball position, the paddle pos and the width of the paddle.
    float ballAngle(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        //by minusing the position of the ball from the paddle you are left with a direction
        //then by diving that by the width of the paddle, you are left with the angle
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    //this runs whenever the ball collides with anthing
   void OnCollisionEnter2D(Collision2D collision)
    {
        //if the ball collides with a gameobject with the name Paddle the code inside will run
        if (collision.gameObject.name == "Paddle")
        {
            //this passes the details of the collision to that function we made earlier.
            float x = ballAngle(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            //this normalises the direction
            Vector2 dir = new Vector2(x, 1).normalized;

            //this gets the velocity of the ball and changes it based on how it hit the paddle.
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }

    
}

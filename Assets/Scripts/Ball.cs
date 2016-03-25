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

    
    void Start()
    {
        // Get the ball's rigid body
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;

		GetComponent<Rigidbody2D>().AddTorque(0.5f);
    }

    
    float ballAngle(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
       
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    
   void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Paddle")
        {
            // Calculate the angle.
            float x = ballAngle(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            // Normalize that shit.
            Vector2 dir = new Vector2(x, 1).normalized;

            // Calculate Velocity.
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }

    
}

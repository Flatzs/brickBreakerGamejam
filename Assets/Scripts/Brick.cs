using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    //this runs whenever anything collides with the brick
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //check if the ball hit us?
        if (collisionInfo.gameObject.name == "Ball")
            //starts the process to destroy.
            StartCoroutine(DestroyBrick());
    }

    //this waits 1 frame then destroys the brick.
    //if you do not use this ienumerator the ball will sometimes go right through the brick without bouncing off.
    IEnumerator DestroyBrick()
    {
        yield return null;

        //this destroys the brick
        Destroy(gameObject);
    }
}

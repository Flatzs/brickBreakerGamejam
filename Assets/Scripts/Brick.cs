using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public float destroyDelay = 0.1f;
	public BoxCollider2D bc2d;

	public Animator bloodSplat;


	void Start(){
		bc2d = GetComponent<BoxCollider2D>();
		//bloodSplat = GetComponentInChildren<Animator>();
	}

    //this runs whenever anything collides with the brick
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //check if the ball hit us?
        if (collisionInfo.gameObject.name == "Ball")
            //starts the process to destroy.
			if (GetComponent<Animator>()){

				GetComponent<Animator>().SetTrigger("collision");

			}
			if (bloodSplat){
			Debug.Log("blood splat");
			bloodSplat.SetTrigger("collision");
			}

            StartCoroutine(DestroyBrick());
    }

    //this waits 1 frame then destroys the brick.
    //if you do not use this ienumerator the ball will sometimes go right through the brick without bouncing off.
    IEnumerator DestroyBrick()
    {
		//yield return new WaitForSeconds(destroyDelay);
		yield return null;
		bc2d.enabled = false;

        //this destroys the brick

        //Destroy(gameObject);
    }
}

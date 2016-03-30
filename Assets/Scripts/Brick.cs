using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public float destroyDelay = 0.1f;
	public BoxCollider2D bc2d;

	public Animator bloodSplat;
	public AudioSource splatSound;


	void Start(){
		splatSound = GameObject.Find ("splatSound").GetComponent<AudioSource>();
		bc2d = GetComponent<BoxCollider2D>();
		StartCoroutine (Resize ());

	}

    //this runs whenever anything collides with the brick
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        if (collisionInfo.gameObject.name == "Ball")
            //starts the process to destroy
			if (GetComponent<Animator>()){

				GetComponent<Animator>().SetTrigger("collision");

			}
			if (bloodSplat){
			Debug.Log("blood splat");
			bloodSplat.SetTrigger("collision");
			}

            StartCoroutine(DestroyBrick());
    }

  
    IEnumerator DestroyBrick()
    {
		splatSound.Play ();
		yield return new WaitForSeconds(destroyDelay);

		//yield return null;
		bc2d.enabled = false;

        //this destroys the brick
		GameObject.Find("gameController").SendMessage("addScore");
		this.transform.position = GameObject.Find("Ball").transform.position;
		this.transform.parent = GameObject.Find("Ball").transform;


       // Destroy(gameObject);
    }

	IEnumerator Resize(){

		while (true) {

			if (Random.Range (0, 5) == 1) {
				float scale = Random.Range (0.5f, 1.5f);
				transform.localScale = new Vector3 (scale, scale, 0.1f);
			}


			yield return new WaitForSeconds (Random.Range(2f,4f));
		}

	}
}

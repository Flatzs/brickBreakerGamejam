using UnityEngine;
using System.Collections;
using System.Xml.Linq;

public class screenEffects : MonoBehaviour {

	public float x = 0.5f;
	public float y = 0.5f;
	public float delay = 0.1f;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void shakeScreen(){
		pos = transform.position;
		StartCoroutine (screenShake ());
	}

	IEnumerator screenShake(){

		float xShake = Random.Range (x * -1f, x);
		float yShake = Random.Range (y * -1f, y);


		transform.position = new Vector3 (transform.position.x + xShake, transform.position.y + yShake, transform.position.z);
		yield return new WaitForSeconds (delay);
		transform.position = pos;
		yield return null;
	}
}

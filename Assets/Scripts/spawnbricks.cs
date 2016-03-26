using UnityEngine;
using System.Collections;

public class spawnbricks : MonoBehaviour {

	public GameObject normalBrick;
	public float xmin = -200f;
	public float xmax = 200;
	public float ymin = 2;
	public float ymax = 100;
	public float xSpacing;
	public float ySpacing;
	public float cols;
	public float rows;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){

		float y = ymin;
		float x = xmin;
		float scale;
		float rot;
		GameObject newObj;


		for (int i = 0; i < cols; i++){

			for (int j = 0; j < rows; j++){
				scale = Random.Range(0.5f, 1.5f);
				rot = Random.Range(0f, 360f);
				newObj = (GameObject)Instantiate(normalBrick,new Vector3(x,y,5f),Quaternion.identity);

				// randomize scale and rotation
				newObj.transform.localScale = new Vector3(scale,scale,transform.localScale.z);
				newObj.transform.Rotate(new Vector3(0f,0f,rot));

				// sort into the brickHolder folder
				newObj.transform.parent = GameObject.Find("brickHolder").transform;

				y += ySpacing * scale;
			}
			y = ymin;
			x += xSpacing;
		}

	}
}

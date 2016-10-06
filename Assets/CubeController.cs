using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	private float speed = -0.2f;
	private float deadLine = -10f;

	AudioSource audio;

	GameObject unitychan;


	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();
		unitychan = GameObject.Find ("UnityChan2D");
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed, 0, 0);
		if (transform.position.x < deadLine) {
			Destroy (gameObject);
		}
	}


		void OnCollisionEnter2D (Collision2D c){
			string yourtag = c.gameObject.tag;
			if(yourtag == "cube"||yourtag == "ground"){
				audio.Play ();
			}

			else if (c.gameObject == unitychan) {
				return;
			}
		}
			

	

}

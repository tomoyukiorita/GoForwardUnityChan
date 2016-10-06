using UnityEngine;
using System.Collections;


public class UnityChanController : MonoBehaviour {

	Animator animator;
	private float groundLevel = -3.0f;

	Rigidbody2D rigid2D;

	private float dump = 0.8f;

	float jumpVelocity = 20f;

	private float deadLine = -9;



	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		rigid2D = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Horizontal", 1);

		bool isGround = (transform.position.y > groundLevel) ? false : true;
		animator.SetBool ("isGround", isGround);

		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

		if(Input.GetMouseButtonDown(0)&&isGround){
			rigid2D.velocity = new Vector2 (0, jumpVelocity);
			}

		if(Input.GetMouseButton (0) == false) {
			if (rigid2D.velocity.y > 0) {
				rigid2D.velocity *= dump;
			}

		
		}
		if (transform.position.x < this.deadLine){
			
			GameObject.Find("Canvas").GetComponent<UIController> ().gameOver ();

			Destroy (gameObject);

	}

		
}
}
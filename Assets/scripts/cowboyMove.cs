using UnityEngine;
using System.Collections;

public class cowboyMove : MonoBehaviour {
	public float speed = 10;
	public float acceleration = 100;
	public float groundFriction = 90;
	Animator a;

	void Start() {
		a = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if ( rigidbody2D.velocity.magnitude < speed )
		{
			Vector2 accelVector = new Vector2 (Input.GetAxisRaw ("Horizontal") * acceleration, Input.GetAxisRaw ("Vertical") * acceleration);
			rigidbody2D.AddForce(accelVector, ForceMode2D.Impulse);
		}
		//Debug.Log (rigidbody2D.velocity.magnitude);

		if (Input.GetKey (KeyCode.R))
			a.SetBool ("reload", true);
		else if(a.GetBool ("reload"))
			a.SetBool ("reload", false);
	}
}

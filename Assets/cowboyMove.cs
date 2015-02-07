using UnityEngine;
using System.Collections;

public class cowboyMove : MonoBehaviour {
	public float speed = 10;
	Animator a;

	void Start() {
		a = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed);

		if (Input.GetKey (KeyCode.R))
			a.SetBool ("reload", true);
		else if(a.GetBool ("reload"))
			a.SetBool ("reload", false);
	}
}

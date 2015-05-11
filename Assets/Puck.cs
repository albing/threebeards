using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	public float forceFactor = 1f;
	public float puckDamage = 1f;

	private bool didDamage = false;

	void Start() {
		var player = GameObject.FindGameObjectWithTag ("Player");

		var force = (player.transform.position - transform.position).normalized * forceFactor;
		rigidbody2D.AddForce(force,ForceMode2D.Impulse);
	}

	// if we're going slow enough, don't get hurt by it
	void Update() {
		if(!didDamage && rigidbody2D.velocity.sqrMagnitude < 1)
		{
			didDamage = true;
		}
	}

	// if we're hit, don't destroy; just leave them around but make them harmless.  Fun ensues.
	void OnCollisionEnter2D(Collision2D other)
	{
		if(!didDamage && other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("DoDamage", puckDamage);
			didDamage = true;
		}
	}
}

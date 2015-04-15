using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
	
	public float speed, rotationSpeed;
	public float acceleration = 10;
	GameObject player;
	Transform target;
	Vector2 last;
	public float kickBack;
	public float damage;

	// should not use Start() here because it is only run once, and if a player is created
	// late in the scene, this will not follow it.  OnEnable() is called every time.
	void OnEnable() {
		player = GameObject.FindWithTag ("Player");
		if(player != null) {
			target = player.transform;
			last = target.position;
		}
	}

	void FixedUpdate(){
		Vector2 dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
		
		last = dir;

		if (rigidbody2D.velocity.magnitude < speed) {
			Vector2 accelVector = new Vector2(last.normalized.x * acceleration,last.normalized.y * acceleration);
			rigidbody2D.AddForce(accelVector,ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name == "Cowboy") {
			player.SendMessage("DoDamage",damage);
			Vector2 hurtVector = new Vector2(last.normalized.x * kickBack,last.normalized.y * kickBack);
			player.rigidbody2D.AddForce(hurtVector,ForceMode2D.Impulse);
		}
	}

}
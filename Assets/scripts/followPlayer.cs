using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
	
	public float speed, rotationSpeed;
	public float acceleration = 10;
	Transform target;
	Vector2 last;
	
	void Awake() {
	}
	
	void Start() {
		target = GameObject.FindWithTag ("Player").transform;
		last = target.position;
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
}
using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public float speed, rotationSpeed;
	Transform target, myTransform;
	Vector3 last;

	void Awake() {
		myTransform = transform;
	}

	void Start() {
		target = GameObject.FindWithTag ("Player").transform;
		last = target.position;
	}

	void Update () {

		Vector3 dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

		if(target.position != last) {
			myTransform.position -= myTransform.up * speed * Time.deltaTime;
			last = target.position;
		}
	}
}
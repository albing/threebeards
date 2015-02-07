using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	Transform target;
	Transform enemyTransform;
	public float speed = 6.58f;
	public float rotationSpeed = 2.95f;

	void Start() {
		enemyTransform = this.GetComponent<Transform> ();
	}

	void Update () {

		target = GameObject.FindWithTag ("Player").transform;
		Vector3 targetHeading = target.position - transform.position;
		Vector3 targetDirection = targetHeading.normalized;

		transform.rotation = Quaternion.LookRotation (targetDirection);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
	}
}
using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	float speed = 0.4f, secondsUntilDestroy = 1.0f, startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.position += speed * gameObject.transform.right;

		if(Time.time - startTime >= secondsUntilDestroy)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "enemy") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		} else if(other.gameObject.tag == "scenery") {
			Destroy (this.gameObject);
		}
	}
}

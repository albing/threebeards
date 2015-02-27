using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	float speed = 0.4f, secondsUntilDestroy = 1.0f, startTime;
	public static int score = 0;

	void Start () {
		startTime = Time.time;
	}

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
			score++;
		} else if(other.gameObject.tag == "scenery") {
			Destroy (this.gameObject);
		}
	}
}

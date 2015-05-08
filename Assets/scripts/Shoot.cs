using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	float speed = 0.4f, secondsUntilDestroy = 1.0f, startTime;
	public static int score = 0;
	public static int killsRemaining = 50;
	public static GameObject KillsRemainingText;
	public static int bossHealth = 15;
	public static int totalShotsTaken = 0;
	public static int totalEnemiesHit = 0;

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

		if(other.isTrigger)
			return;

		if(other.gameObject.tag == "enemy") 
		{
			totalEnemiesHit++;
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			score++;
			if (KillsRemainingUpdater.KillsRemainingText.activeSelf && killsRemaining > 0)
				killsRemaining--;
		} 
		else if (other.gameObject.tag == "scenery")
			Destroy (this.gameObject);
		else if (other.gameObject.tag == "boss") 
		{
			totalEnemiesHit++;
			other.gameObject.SendMessage("DoDamage",7.0);
			Destroy(this.gameObject);
		}
	}
}

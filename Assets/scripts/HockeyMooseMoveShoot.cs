using UnityEngine;
using System.Collections;

public class HockeyMooseMoveShoot : MonoBehaviour {

	public float speed;
	public float acceleration = 10;
	public float kickback, damage;
	public int stopTime;
	public float stoppingPower;
	public GameObject puck;

	GameObject player;
	Transform stickPos;
	Transform target;
	Vector2 last;
	
	private bool stopAndShoot;
	private int stopCounter;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		target = player.transform;
		last = target.position;
		stopAndShoot = false;
		stickPos = transform.FindChild ("ShootPoint");
	}
	
	
	void FixedUpdate () {
		if(stopAndShoot)
		{
			Vector2 dir = rigidbody2D.velocity;
			int xNeg = dir.x > 0 ? 1 : -1;
			int yNeg = dir.y > 0 ? 1 : -1;
			Vector2 accelVector = new Vector2(-xNeg * stoppingPower * Mathf.Sqrt(Mathf.Abs( dir.x)),-yNeg * stoppingPower *  Mathf.Sqrt(Mathf.Abs( dir.y )));
			rigidbody2D.AddForce(accelVector,ForceMode2D.Impulse);
		
			stopCounter++;
			if(stopCounter >= stopTime)
			{
				stopAndShoot = false;
				Instantiate(puck, stickPos.position, stickPos.rotation);
				stopCounter = 0;
			}
		}
		else
		{
			Vector2 dir = target.position - transform.position;
			if (rigidbody2D.velocity.magnitude < speed) {
				Vector2 accelVector = new Vector2(dir.normalized.x * acceleration,dir.normalized.y * acceleration);
				rigidbody2D.AddForce(accelVector,ForceMode2D.Impulse);
			}
			
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			player.SendMessage("DoDamage",damage);
			Vector2 hurtVector = new Vector2(last.normalized.x * kickback,
			                                 last.normalized.y * kickback);
			player.rigidbody2D.AddForce(hurtVector,ForceMode2D.Impulse);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") {
			stopAndShoot = true;
			stopCounter = 0;
		}
	}
	
//	void OnTriggerStay2D(Collider2D other) 
//	{
//		if (other.tag == "Player" && stopAndShoot == false) {
//			stopAndShoot = true;
//			stopCounter = 0;
//		}
//	}
}

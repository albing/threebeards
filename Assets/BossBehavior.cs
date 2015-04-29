using UnityEngine;
using System.Collections;

public class BossBehavior : MonoBehaviour {

	public float speed, rotationSpeed;
	public float acceleration = 10;
	GameObject player;
	Transform target;
	Vector2 last;
	public float kickBack;
	public float jumpDistance = 30;
	public float damage;

	
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

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

		last = dir;
		
		if (rigidbody2D.velocity.magnitude < speed) {
			Vector2 accelVector = new Vector2(last.normalized.x * acceleration,last.normalized.y * acceleration);
			rigidbody2D.AddForce(accelVector,ForceMode2D.Impulse);
		}

		// update the animator with our new speed
		anim.SetFloat ("speed", speed);

		// if we're facing the wrong way, point us back again.
		var velocity = rigidbody2D.velocity;
		var scale = transform.localScale;
		if ((velocity.x < 0 && scale.x < 0)  ||  (velocity.x > 0 && scale.x > 0))
			gameObject.transform.localScale = new Vector2(-scale.x, scale.y);
	}

	void Update()
	{
		if(Vector2.SqrMagnitude(target.position - transform.position) < (jumpDistance * jumpDistance))
		{
			anim.SetBool("jumping", true);
		}
	}

	// stop the jump animation.  if the player is still in the zone of influence, do extra damage.
	public void unJump()
	{
		anim.SetBool ("jumping", false);
		if(Vector2.SqrMagnitude(target.position - transform.position) < (jumpDistance * jumpDistance))
		{
			giveDamage(damage * 3, kickBack * 3);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name == "Cowboy") {
			giveDamage(damage, kickBack);
		}
	}

	private void giveDamage(float damageAmount, float kickbackAmount)
	{
		player.SendMessage("DoDamage",damageAmount);
		Vector2 hurtVector = new Vector2(last.normalized.x * kickbackAmount,
		                                 last.normalized.y * kickbackAmount);
		player.rigidbody2D.AddForce(hurtVector,ForceMode2D.Impulse);
	}
}

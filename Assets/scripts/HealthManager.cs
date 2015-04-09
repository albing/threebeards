using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public static float health = 100;
	public GameObject healthBar;

	void Update () {
		if (health > 0)
			healthBar.SendMessage ("setHealth", health);
	}

	public float GetHealth()
	{
		return health;
	}

	public void SetHealth(float newHealth)
	{
		health = newHealth;
		if (health <= 0) {
			Die ();
		}

	}

	public void DoDamage(float damage)
	{
		health -= damage;
		if (health <= 0) {
			Die();
		}
	}

	void Die()
	{
		Debug.Log ("You are dead. Sorry your body didn't get the message");
	}
}

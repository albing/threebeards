using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public float health = 100f;
	public GameObject healthBar;

	void Update () {
		if (health > 0 && healthBar != null && healthBar.gameObject.activeInHierarchy)
			healthBar.SendMessage ("SetHealth", health);
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
		if(!CompareTag("Player"))
			GameObject.Destroy(gameObject);
	}
}

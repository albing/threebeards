using UnityEngine;
using System.Collections;

public class RockOfDoomTrigger : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Cowboy")
		{
			GameObject[] spawns = GameObject.FindGameObjectsWithTag ("enemyspawn");
			foreach(var spawn in spawns)
			{
				Instantiate (enemy, spawn.transform.position, spawn.transform.rotation);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		Debug.Log ("Object Stayed in Collider : " + other.name);
	}

	void OnTriggerExit2D(Collider2D other ) {
		Debug.Log ("Object Left Collider : " + other.name);
	}

}

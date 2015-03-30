using UnityEngine;
using System.Collections;

public class RockOfDoomTrigger : MonoBehaviour {

	public GameObject enemy;
	public GameObject usaFlag;
	public GameObject cadFlag;
	private bool hasBeenTriggered = false;
	private Object flag;
	
	void Start(){
		flag = Instantiate(cadFlag);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Cowboy")
		{
			GameObject[] spawns = GameObject.FindGameObjectsWithTag ("enemyspawn");
			foreach(var spawn in spawns)
			{
				Instantiate (enemy, spawn.transform.position, spawn.transform.rotation);
			}
			GameObject.Find("EnemyManager").SendMessage("StartSpawning");
			if(!hasBeenTriggered)
			{
				DestroyObject(flag);
				flag = Instantiate(usaFlag);
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

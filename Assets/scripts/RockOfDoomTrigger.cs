using UnityEngine;
using System.Collections;

public class RockOfDoomTrigger : MonoBehaviour {

	public GameObject enemy;
	public GameObject usaFlag;
	public GameObject cadFlag;
	public GameObject verticalFence;
	private bool hasBeenTriggered = false;
	private Object flag;
	private Object fence;
	
	void Start(){
		flag = Instantiate(cadFlag);
		fence = new Object ();
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
				hasBeenTriggered = true;
				fence = Instantiate (verticalFence);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
	}

	void OnTriggerExit2D(Collider2D other ) {
	}

}

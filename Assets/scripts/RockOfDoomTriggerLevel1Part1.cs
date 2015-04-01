using UnityEngine;
using System.Collections;

public class RockOfDoomTriggerLevel1Part1 : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject usaFlag;
	public GameObject cadFlag;
	public GameObject Trees1;
	public GameObject Trees2;
	public GameObject Trees3;
	private bool hasBeenTriggered = false;
	private Object flag;
	private Object tree1;
	private Object tree2;
	private Object tree3;
	
	void Start(){
		flag = Instantiate(cadFlag);
		tree1 = new Object ();
		tree2 = new Object ();
		tree3 = new Object ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Cowboy")
		{
			if (Shoot.score < 51)
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
					tree1 = Instantiate (Trees1);
					tree2 = Instantiate (Trees2);
					tree3 = Instantiate (Trees3);
				}
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

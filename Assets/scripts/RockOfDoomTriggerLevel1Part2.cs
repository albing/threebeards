using UnityEngine;
using System.Collections;

public class RockOfDoomTriggerLevel1Part2 : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject usaFlag;
	public GameObject cadFlag;
	public GameObject Trees1;
	public GameObject Trees2;
	public GameObject Trees3;
	public GameObject redLight;
	public GameObject blueLight;
	private bool hasBeenTriggered = false;
	private Object flag;
	private Object tree1;
	private Object tree2;
	private Object tree3;
	private Object red;
	private Object blue;
	private static int maxScore = 1000;
	
	void Start(){
		cadFlag.transform.position = new Vector2 (-0.8f, -27.9f);
		flag = Instantiate(cadFlag);
		tree1 = new Object ();
		tree2 = new Object ();
		tree3 = new Object ();
		red = new Object ();
		blue = new Object ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Cowboy")
		{
			if (Shoot.score < maxScore)
			{
				KillsRemainingUpdater.KillsRemainingText.SetActive (true);
				GameObject[] spawns = GameObject.FindGameObjectsWithTag ("enemyspawn2");
				foreach(var spawn in spawns)
				{
					Instantiate (enemy, spawn.transform.position, spawn.transform.rotation);
				}
				GameObject.Find("EnemyManager2").SendMessage("StartSpawning");
				if(!hasBeenTriggered)
				{
					redLight.transform.position = new Vector3 (-0.8f, -27.9f, -1.7f);
					red = Instantiate (redLight);
					usaFlag.transform.position = new Vector2 (-0.8f, -27.9f);
					maxScore = Shoot.score + 51;
					DestroyObject(flag);
					flag = Instantiate(usaFlag);
					tree1 = Instantiate (Trees1);
					tree2 = Instantiate (Trees2);
					tree3 = Instantiate (Trees3);
					hasBeenTriggered = true;
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

	public void BeatSection()
	{
		blueLight.transform.position = new Vector3 (-0.8f, -27.9f, -1.7f);
		DestroyObject (red);
		blue = Instantiate (blueLight);
	}
}

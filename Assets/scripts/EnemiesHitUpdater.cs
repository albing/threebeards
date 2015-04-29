using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemiesHitUpdater : MonoBehaviour {
	
	Text instruction;
	
	void Start () {
		instruction = GetComponent<Text> ();
	}
	
	void Update () {
		instruction.text = "Enemies Hit: " + Shoot.totalEnemiesHit;
	}
}
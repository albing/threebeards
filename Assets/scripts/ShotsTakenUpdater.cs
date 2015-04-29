using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotsTakenUpdater : MonoBehaviour {
	
	Text instruction;
	
	void Start () {
		instruction = GetComponent<Text> ();
	}
	
	void Update () {
		instruction.text = "Shots Taken: " + Shoot.totalShotsTaken;
	}
}

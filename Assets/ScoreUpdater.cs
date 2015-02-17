using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	Text instruction;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		instruction.text = "Score: " + Shoot.score;
	}
}

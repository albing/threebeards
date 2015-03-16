using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	Text instruction;

	void Start () {
		instruction = GetComponent<Text> ();
	}

	void Update () {
		instruction.text = "Score: " + Shoot.score;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillsRemainingUpdater : MonoBehaviour {
	
	Text instruction;
	public static GameObject KillsRemainingText;

	void Start () {
		instruction = GetComponent<Text> ();
		KillsRemainingText = GameObject.Find ("Canvas/KillsRemainingText");
		KillsRemainingText.SetActive (false);
	}
	
	void Update () {
		instruction.text = "Kills Remaining: " + Shoot.killsRemaining;
	}
}

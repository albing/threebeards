using UnityEngine;
using System.Collections;

public class LevelChangeScript : MonoBehaviour {

	public void tutorialLevel()
	{
		Shoot.score = 0;
		Application.LoadLevel ("Tutorial Level");
	}

	public void levelSelectScreen()
	{
		Application.LoadLevel ("Level Select");
	}
}

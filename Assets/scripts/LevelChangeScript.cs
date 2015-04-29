using UnityEngine;
using System.Collections;

public class LevelChangeScript : MonoBehaviour {

	public HealthManager playerHealth;

	public void tutorialLevel()
	{
		Shoot.score = 0;
		if(playerHealth)
			playerHealth.SetHealth(100);
		Application.LoadLevel ("Tutorial Level");;
	}

	public void levelSelectScreen()
	{
		Application.LoadLevel ("Level Select");
	}

	public void LevelOne()
	{
		Shoot.score = 0;
		if(playerHealth)
			playerHealth.SetHealth(100);
		Application.LoadLevel ("Level 1");
	}
	public void LevelTwo()
	{
		Shoot.score = 0;
		if(playerHealth)
			playerHealth.SetHealth(100);
		Application.LoadLevel ("Level 2");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}

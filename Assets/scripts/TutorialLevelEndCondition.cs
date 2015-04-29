using UnityEngine;
using System.Collections;

public class TutorialLevelEndCondition : MonoBehaviour {

	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;
	public GameObject deadPanel;
	public HealthManager playerHealth;

	private GameObject scoreText, messageCanvas, healthBar;
	private bool halted = false;
	private bool dead = false;
	private bool beatLevel = false;

	void Start() {
		Shoot.totalEnemiesHit = 0;
		Shoot.totalShotsTaken = 0;
		Shoot.killsRemaining = 20;
		scoreText = GameObject.Find ("Score Text");
		messageCanvas = GameObject.Find ("Message Canvas");
		healthBar = GameObject.FindGameObjectWithTag ("healthbar");
		unhalt ();
	}
	
	// TODO: OnPauseGame event: 
	// http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
	void Update() {
		if(Shoot.score >= 26 && !halted)
		{
			halted = !halted;
			beatLevel = true;
			playerHealth.health = 0;
			halt ();
		}

		if (playerHealth.health <= 0 && !halted) {
			halted = !halted;
			dead = true;
			playerHealth.health = 0;
			halt ();
		}
	}

	private void halt()
	{
		Time.timeScale = 0;
		
		if(beatLevel)
			victoryPanel.SetActive(true);

		if (dead)
			deadPanel.SetActive (true);

		healthBar.SetActive (false);
		messageCanvas.SetActive (false);
		scoreText.SetActive(false);
	}

	public void unhalt()
	{
		Time.timeScale = 1.0f;;
	}
}

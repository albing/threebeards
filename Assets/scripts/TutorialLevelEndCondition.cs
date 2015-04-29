using UnityEngine;
using System.Collections;

public class TutorialLevelEndCondition : MonoBehaviour {

	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;
	public GameObject deadPanel;
	public GameObject pausedPanel;
	public HealthManager playerHealth;

	private GameObject scoreText, messageCanvas, healthBar;
	private bool paused = false;
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
		if (paused) 
		{
			if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P))
			{
				unhalt ();
			}
		}
		else if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) 
		{
			paused = true;
			halt ();
		}

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

		if (paused)
			pausedPanel.SetActive (true);

		healthBar.SetActive (false);
		messageCanvas.SetActive (false);
		if (!paused) 
		{
			scoreText.SetActive (false);
		}
	}

	public void unhalt()
	{
		paused = false;
		healthBar.SetActive (true);
		messageCanvas.SetActive (true);
		if (pausedPanel)
			pausedPanel.SetActive (false);
		Time.timeScale = 1.0f;;
	}
}

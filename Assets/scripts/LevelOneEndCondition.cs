using UnityEngine;
using System.Collections;

public class LevelOneEndCondition : MonoBehaviour {
	
	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;
	public GameObject deadPanel;
	public HealthManager playerHealth;
	public GameObject boss;
	public GameObject playerHealthBar;
	public GameObject pausedPanel;
	
	private GameObject scoreText;
	private bool halted = false;
	private bool dead = false;
	private bool beatLevel = false;
	private bool paused = false;
	
	void Start() {
		Shoot.totalEnemiesHit = 0;
		Shoot.totalShotsTaken = 0;
		Shoot.killsRemaining = 50;
		scoreText = GameObject.Find ("Score Text");
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
		if(boss == null && !halted)
		{
			halted = !halted;
			beatLevel = true;
			halt ();
		}
		
		if (playerHealth.health <= 0 && !halted) {
			halted = !halted;
			dead = true;
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

		playerHealthBar.SetActive (false);
		if (!paused)
			scoreText.SetActive(false);
	}
	
	public void unhalt()
	{
		paused = false;
		playerHealthBar.SetActive (true);
		if (pausedPanel)
			pausedPanel.SetActive (false);
		Time.timeScale = 1.0f;;
	}
}
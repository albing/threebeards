using UnityEngine;
using System.Collections;

public class LevelOneEndCondition : MonoBehaviour {
	
	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;
	public GameObject deadPanel;
	public HealthManager playerHealth;
	public GameObject boss;
	public GameObject playerHealthBar;
	
	private GameObject scoreText;
	private bool halted = false;
	private bool dead = false;
	private bool beatLevel = false;
	
	void Start() {
		scoreText = GameObject.Find ("Score Text");
		unhalt ();
	}
	
	// TODO: OnPauseGame event: 
	// http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
	void Update() {
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

		playerHealthBar.SetActive (false);
		scoreText.SetActive(false);
	}
	
	public void unhalt()
	{
		Time.timeScale = 1.0f;;
	}
}
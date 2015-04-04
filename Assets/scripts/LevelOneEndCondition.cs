using UnityEngine;
using System.Collections;

public class LevelOneEndCondition : MonoBehaviour {
	
	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;
	public GameObject deadPanel;

	private GameObject healthBar;
	private GameObject scoreText;
	private bool halted = false;
	private bool dead = false;
	private bool beatLevel = false;
	
	void Start() {
		scoreText = GameObject.Find ("Score Text");
		healthBar = GameObject.FindGameObjectWithTag ("healthbar");
		unhalt ();
	}
	
	// TODO: OnPauseGame event: 
	// http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
	void Update() {
		if(Shoot.score >= 200 && !halted) // this will need to be changed later.
		{
			halted = !halted;
			beatLevel = true;
			halt ();
		}
		
		if (HealthManager.health <= 0 && !halted) {
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

		healthBar.SetActive (false);
		scoreText.SetActive(false);
	}
	
	public void unhalt()
	{
		Time.timeScale = 1.0f;;
	}
}
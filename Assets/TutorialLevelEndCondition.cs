using UnityEngine;
using System.Collections;

public class TutorialLevelEndCondition : MonoBehaviour {

	// have to make this one public because it starts out as inactive
	public GameObject victoryPanel;

	private GameObject messageCanvas, scoreText;
	private bool halted = false;

	void Start() {
		messageCanvas = GameObject.Find ("Message Canvas");
		scoreText = GameObject.Find ("Score Text");
		unhalt ();
	}
	
	// TODO: OnPauseGame event: 
	// http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
	void Update() {
		if(Shoot.score >= 20 && !halted)
		{
			halted = !halted;
			halt ();
		}
	}

	private void halt()
	{
		Time.timeScale = 0;
		
		if(victoryPanel)
			victoryPanel.SetActive(true);
		
		messageCanvas.SetActive(false);
		scoreText.SetActive(false);
	}

	public void unhalt()
	{
		Time.timeScale = 1.0f;
	}
}

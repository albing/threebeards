using UnityEngine;
using System.Collections;

public class Level1IntroCutscene : MonoBehaviour {
	
	public GameObject playableCowboy, beavers;
	public Canvas canvas;
	public Canvas cutsceneCanvas;
	public LevelOneEndCondition endCondition;

	void Update() {
		if(Input.GetKeyDown(KeyCode.X))
		{
			EndCutscene();
			cutsceneCanvas.gameObject.SetActive(false);
		}
	}

	void Start () {
		beavers.SetActive (false);
		canvas.gameObject.SetActive (false);
		endCondition.enabled = false;
	}

	public void EndCutscene()
	{
		playableCowboy.SetActive (true);
		this.gameObject.SetActive (false);
		beavers.SetActive (true);
		canvas.gameObject.SetActive (true);
		endCondition.enabled = true;
		var canv = GameObject.Find ("Message Canvas");
		if (canv)
			Destroy (canv);
	}
}

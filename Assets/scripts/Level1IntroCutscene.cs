using UnityEngine;
using System.Collections;

public class Level1IntroCutscene : MonoBehaviour {
	
	public GameObject playableCowboy, beavers;
	public GameObject boat;
	public Canvas canvas;
	public Canvas cutsceneCanvas;
	public LevelOneEndCondition endCondition;

	void Update() {
		if(Input.GetKeyDown(KeyCode.X))
		{
			EndCutscene();
		}
	}

	void Start () {
		beavers.SetActive (false);
		canvas.gameObject.SetActive (false);
		endCondition.enabled = false;
	}

	public void EndCutscene()
	{
		cutsceneCanvas.gameObject.SetActive(false);
		playableCowboy.SetActive (true);
		this.gameObject.SetActive (false);
		beavers.SetActive (true);
		canvas.gameObject.SetActive (true);
		endCondition.enabled = true;
		var canv = GameObject.Find ("Message Canvas");
		if (canv)
			Destroy (canv);
		boat.transform.position = new Vector2 (-25.0f, -60.0f);
		Instantiate (boat);
	}
}

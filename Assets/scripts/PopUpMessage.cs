using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour {

	public string text;
	public Canvas canvas;
	public MessageDestroyType destroyType = MessageDestroyType.Time;

	private float timeRemaining = 2;

	public enum MessageDestroyType {Time, PauseAndWaitForClick, Proximity, Never};


	void Start () {
		if(!canvas)
			canvas = GameObject.Find("Message Canvas").GetComponent<Canvas>();

		transform.SetParent (canvas.transform);
		transform.right = Vector3.zero;
		transform.localPosition = Vector2.zero;

		if(!string.IsNullOrEmpty(text))
		{
			Text t = transform.GetComponentInChildren<Text> ();

			t.text = this.text;
		}
	}

	void Update() {
		switch (destroyType) {
		case MessageDestroyType.Time:
			if(timeRemaining > 0)
				timeRemaining -= Time.deltaTime;
			else
			{
				Destroy(gameObject);
			}
			break;
		case MessageDestroyType.PauseAndWaitForClick:
			// TODO: not implemented!
			Debug.LogError ("Pause and Wait for Click not implemented!");
			break;
		case MessageDestroyType.Proximity:
			// TODO: not really implemented?  See AreaTrigger.cs
			break;
		case MessageDestroyType.Never:
			// TODO: done, but is this ever going to be useful?
			break;
		}
	}

	public void setTimeRemaining(float t)
	{
		timeRemaining = t;
	}
}

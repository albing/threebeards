using UnityEngine;
using System.Collections;

public class SignTrigger : MonoBehaviour {

	public GameObject textBoxObject;

	void OnTriggerEnter2D(Collider2D other) {

		if(other.CompareTag("Player"))
		{
			var canvas = GameObject.Find ("Message Canvas");
			if(!canvas)
			{
				var c = Instantiate(new Canvas());
				c.name = "Message Canvas";
			}

			var message = ((GameObject) Instantiate(textBoxObject)).GetComponent<PopUpMessage>();
			message.text = "DO NOT TOUCH THE ROCK OF DOOM!";
			message.setTimeRemaining(3.5f);
		}
	}
}

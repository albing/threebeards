using UnityEngine;
using System.Collections;

public class AreaTrigger : MonoBehaviour {

	public string text;
	public GameObject messageWindowObject;

	private GameObject message;

	void OnTriggerEnter2D(Collider2D other) {

		if(other.CompareTag("Player"))
		{
			var canvas = GameObject.Find ("Message Canvas");
			if(!canvas)
			{
				var c = Instantiate(new Canvas());
				c.name = "Message Canvas";
			}
			
			message = (GameObject) Instantiate(messageWindowObject);

			var pum = message.GetComponent<PopUpMessage>();
			pum.destroyType = PopUpMessage.MessageDestroyType.Proximity;

			if(!string.IsNullOrEmpty(text))
				pum.text = this.text;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player"))
			Destroy (message);
	}

}

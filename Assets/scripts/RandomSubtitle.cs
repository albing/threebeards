using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RandomSubtitle : MonoBehaviour {

	private Text text;
	public TextAsset titles;

	string[] names = {
		"Almighty Pogo Scandal",
		"In Search of Flatulence Unleashed",
		"Ebony Midget Sisters",
		"Shameful Vegetarian Odyssey",
		"Intellectual Internet Legends"
	};

	void Start () {

		if(titles)
		{
			names = Regex.Split (titles.text, @"[\n\r|\r\n|\r|\n]");
		}
		
		text = GetComponent<Text> ();
		Random.seed = (int) System.DateTime.Now.Ticks;
		
		getNewName ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.T)) {
			getNewName ();
		}
	}

	private void getNewName() {
		text.text = names [Random.Range (0, names.Length)];
	}
}

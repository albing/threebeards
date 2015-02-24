using UnityEngine;
using System.Collections;

public class textBounce : MonoBehaviour {

	Vector3 larger = new Vector3 (1f, 1f, 1f);
	Vector3 smaller = new Vector3 (0.8f, 0.8f, 0.8f);

	public float speed;

	RectTransform rt;

	void Start () {

		rt = GetComponent<RectTransform> ();
	}
	
	void Update () {
		rt.localScale = Vector3.Lerp(larger, smaller, Mathf.PingPong(Time.time * speed, 1f));
	}
}

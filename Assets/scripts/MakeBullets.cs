using UnityEngine;
using System.Collections;

public class MakeBullets : MonoBehaviour {

	public GameObject bullet;
	public AudioClip fireSound;

	public void fire()
	{
		Instantiate (bullet, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}

	void Update() {
		if(Input.GetButtonDown ("Fire1") && Time.timeScale != 0) {
			fire();
		}
	}
}

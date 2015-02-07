using UnityEngine;
using System.Collections;

public class MakeBullets : MonoBehaviour {

	public GameObject bullet;

	public void fire()
	{
		Instantiate (bullet, transform.position, transform.rotation);

	}

	void Update() {
		if(Input.GetButtonDown ("Fire1")) {
			fire();
		}
	}
}

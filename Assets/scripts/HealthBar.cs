using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	Vector3 scale;
	float xScaleFactor;

	void Start()
	{
		scale = transform.localScale;
		xScaleFactor = scale.x;
	}

	void setHealth(float health)
	{
		Debug.Log (health);
		scale.x = (health / 100) * xScaleFactor;
		transform.localScale = scale;
	}
}

using UnityEngine;
using System.Collections;


/*
 * N.B.: The object this is attached to should be x-scaled at 1
 * 
 */


public class HealthBar : MonoBehaviour {

	Vector3 scale;

	void Start()
	{
		scale = transform.lossyScale;
	}

	void setHealth(float health)
	{
		scale.x = health / 100;
		transform.localScale = scale;
	}
}

using UnityEngine;
using System.Collections;

public class DeathNoises : MonoBehaviour {

	public AudioClip[] deathSounds;

	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("player projectile"))
			AudioSource.PlayClipAtPoint(deathSounds[Random.Range(0, deathSounds.Length)], transform.position);
	}
}

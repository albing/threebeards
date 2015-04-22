using UnityEngine;
using System.Collections;

public class LivingNoises : MonoBehaviour {

	public AudioClip[] clips;
	public float delayInSeconds;

	private AudioSource source;
	private float time = 0;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		time += Time.deltaTime;

		if(time > delayInSeconds)
		{
			time = 0;
			source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
		}
	}
}
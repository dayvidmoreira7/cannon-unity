using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetup : MonoBehaviour {

	public AudioClip soundEffect;
	float duration;

	AudioSource mySource;

	public bool setup = false;
	float time;

	void Start ()
	{
		mySource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (setup)
		{
			Setup();
			setup = false;
		}

		time += 1f * Time.deltaTime;
		if (time > duration)
		{
			Destroy(gameObject);
		}
	}

	void Setup()
	{
		duration = soundEffect.length;
		mySource.clip = soundEffect;
		mySource.Play();
	}
}

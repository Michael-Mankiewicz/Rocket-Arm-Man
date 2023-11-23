using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screaming : MonoBehaviour {
	private AudioSource audioSource;
	public AudioClip[] shoot;
	private AudioClip shootClip;
	public ArmHolder armHolder;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		 audioSource.outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0) && StaticThings.GameIsPaused == false) {
			if (armHolder.HasArms()) {
				int index = Random.Range (0, shoot.Length);
				shootClip = shoot [index];
				audioSource.clip = shootClip;
				audioSource.pitch = Random.Range (0.9f, 1f);
				audioSource.Play ();
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEditor;
public class Triggered : MonoBehaviour {
	public Animator anim;
	private float pitch = 1f;
	public bool triggered = false;
	public AudioClip[] audioh;
	public AudioSource[] _sources;
	private Light lite;
	// Use this for initialization
	void Start () {
		
		pitch = Random.Range (0.8f, 1.2f);
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			  _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;
			  _sources[i].spatialBlend = 0f;
			  _sources[i].pitch = pitch;
			  _sources[i].volume = 1f;
			 // _sources[i].minDistance = 20f;
			// _sources[i].maxDistance = 250f;
             // set up the properties such as distance for 3d sounds here if you need to.
         }

		 for(int i = 0; i < transform.parent.childCount; i++){
			 if(transform.parent.GetChild(i).GetComponent<Light>() != null)
			 	lite = transform.parent.GetChild(i).GetComponent<Light>();
		 }
		 lite.color = Color.red;
		 lite.intensity = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click(){
		_sources[0].Play();
		lite.color = Color.green;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEditor;
public class ExplosionSoundFX : MonoBehaviour {
	public AudioClip[] audioh;
	public AudioSource[] _sources;
	// Use this for initialization
	int index = 0;
	void Start () {
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			 _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;//((AudioMixerGroup)AssetDatabase.LoadAssetAtPath("Assets/Sound/NewAudioMixer.mixer", typeof(AudioMixerGroup)));
			  _sources[i].spatialBlend = 1f;
			  _sources[i].minDistance = 5f;
			 _sources[i].maxDistance = 300f;
             // set up the properties such as distance for 3d sounds here if you need to.
         }
		 float chance = Random.Range (0f, audioh.Length-1f);
		
		 if(chance > 0.5f){
			 index = 1;
		 } else {
			 index = 0;
		 }
		_sources[index].pitch = Random.Range (0.7f, 1.3f);
		_sources[index].Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

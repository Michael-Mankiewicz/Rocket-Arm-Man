using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.UI;
public class UISound : MonoBehaviour {
	public AudioClip[] audioh;
	private AudioSource[] _sources;
	void Start () {
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			 //_sources[i].outputAudioMixerGroup = ((AudioMixerGroup)AssetDatabase.LoadAssetAtPath("Assets/Sound/NewAudioMixer.mixer", typeof(AudioMixerGroup)));
			 _sources[i].volume = 0.1f;
             // set up the properties such as distance for 3d sounds here if you need to.
         }
	}
	public void Hover(){
		_sources[0].Play();
	}
	public void Press(){
		_sources[1].Play();
	}

}

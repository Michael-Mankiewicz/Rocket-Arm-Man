using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Zapper : MonoBehaviour {
	AudioSource[] _sources;
	public AudioClip[] audioh;
	void Start(){
		
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			_sources[i].spatialBlend = 1f;
			_sources[i].dopplerLevel = 0.5f;
			_sources[i].rolloffMode = AudioRolloffMode.Logarithmic;
			 _sources[i].minDistance = 20f;
			 _sources[i].maxDistance = 300f;
			  _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;
         }
		_sources[0].Play();
		_sources[0].loop = true;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.layer == 11){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		}
	}
}

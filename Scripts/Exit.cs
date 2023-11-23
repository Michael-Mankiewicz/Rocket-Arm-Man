using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
//using UnityEditor;
public class Exit : MonoBehaviour {
	public Light light;
	 AudioSource[] _sources;
	 public AudioClip[] audioh;
	private bool isOn = true;
	public Triggered[] buttons;
	bool thereAreButtons = false;
	float prevIntensity;
	BoxCollider2D memeCol;
	// Use this for initialization
	void Start () {
		memeCol = GetComponent<BoxCollider2D>();
		memeCol.isTrigger = true;
		//print("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + "maxLevel: " + PlayerPrefs.GetInt("maxLevel"));
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
			  _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;//((AudioMixerGroup)AssetDatabase.LoadAssetAtPath("Assets/Sound/NewAudioMixer.mixer", typeof(AudioMixerGroup)));
             // set up the properties such as distance for 3d sounds here if you need to.
         }
		

		foreach(Triggered booty in buttons){
			if(booty != null)
			thereAreButtons = true;
		}

		if(thereAreButtons){
			isOn = false;
			_sources[0].pitch = 0.7f;
		}
		_sources[0].Play();
		
		_sources[0].loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		int bootiesTriggered = 0;

		foreach(Triggered booty in buttons){
			if(booty.triggered)
				bootiesTriggered++;
		}

		if(bootiesTriggered == buttons.Length && thereAreButtons){
			Work();
		}

		if(isOn == false){
			light.color = Color.red;
			prevIntensity = light.intensity;
			light.intensity = 1f;
		}
	}
	void Work(){
		isOn = true;
		light.color = new Color(90f/256, 217f/256, 255f/256, 255f/256);
		light.intensity = prevIntensity;
		_sources[0].pitch = 1f;
		_sources[1].Play();
	}
	void OnTriggerEnter2D(Collider2D coll){
		StaticThings.firstTimePlayingLevel = true;
		if (coll.gameObject.layer == 11 && isOn ) {
			//print("activescene: " + SceneManager.GetActiveScene ().buildIndex + "  scenecount: " + SceneManager.sceneCountInBuildSettings);
			/*if(PlayerPrefs.GetInt("maxLevel") == 0){
				PlayerPrefs.SetInt ("maxLevel", 1);
			}*/
			//increase max level if the next level is larger than max level and if the next scene is within the built scenes
			if(SceneManager.GetActiveScene ().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings - 1){
				SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
				PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene ().buildIndex + 1); 
				if(PlayerPrefs.GetInt("currentLevel", 1) > PlayerPrefs.GetInt("maxLevel",1))
				PlayerPrefs.SetInt ("maxLevel", PlayerPrefs.GetInt("currentLevel", 1));
			} else {
				SceneManager.LoadScene(0);
			}

			//print("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + "maxLevel: " + PlayerPrefs.GetInt("maxLevel"));
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class CameraFXHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("simpleCameraEffects") == 0){
			if(gameObject.GetComponent<PostProcessingBehaviour>() != null)
				gameObject.GetComponent<PostProcessingBehaviour>().profile = Resources.Load<PostProcessingProfile>("Game");
		} else {
			if(gameObject.GetComponent<PostProcessingBehaviour>() != null)
				gameObject.GetComponent<PostProcessingBehaviour>().profile = Resources.Load<PostProcessingProfile>("Simple");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

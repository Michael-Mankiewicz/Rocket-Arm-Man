using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBlink : MonoBehaviour {

	// Use this for initialization
	Triggered tigger;
	Light blinker;
	void Start () {
		if(gameObject.GetComponent<Light>() != null){
				blinker = gameObject.GetComponent<Light>();
		}
		for(int i = 0; i <= transform.parent.childCount; i++){
				if (transform.parent.GetChild(i).GetComponent<Triggered>() != null){
					tigger = transform.parent.GetChild(i).GetComponent<Triggered>();
				}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(tigger.triggered){
			blinker.intensity = 0f;
		}
	}
}

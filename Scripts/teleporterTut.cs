using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterTut : MonoBehaviour {
	public Transform man;
	public Transform cam;
	private List<Transform> places = new List<Transform>();
	public Transform placeHolder;
	// Use this for initialization
	private int placesIndex = 0;

	void Start(){
		for(int i = 0; i < placeHolder.childCount ; i++){
			places.Add(placeHolder.GetChild(i));
		}
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(placesIndex == places.Count - 1){
				placesIndex = 0;
			} else {
				placesIndex++;
			}
			cam.position = places[placesIndex].position + new Vector3(0, 0, StaticThings.offsetZ);
			man.position = places[placesIndex].position;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(placesIndex == 0){
				placesIndex = places.Count - 1;
			} else {
				placesIndex--;
			}
			cam.position = places[placesIndex].position + new Vector3(0, 0, StaticThings.offsetZ);;
			man.position = places[placesIndex].position;
		}
	}
}

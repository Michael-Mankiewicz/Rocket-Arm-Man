using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserlights : MonoBehaviour {

	public List<Light> lights = new List<Light>();
	Color originalColor;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < gameObject.transform.childCount; i++) {
			Transform currentChild = gameObject.transform.GetChild (i);
			lights.Add(currentChild.GetComponent<Light>());
		}
		originalColor = lights[0].color;
	}
	
	// Update is called once per frame
	void Update () {
		float randomNum = Random.Range(-50/256f, 0f);
		Color variedColor = new Color(originalColor.r + randomNum, originalColor.g, originalColor.b);
		for (int i = 0; i < lights.Count; i++){
			lights[i].color = variedColor;
		}
	}
}

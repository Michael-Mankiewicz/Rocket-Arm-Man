﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Boom ());
	}
	
	IEnumerator Boom(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}

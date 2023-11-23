using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Save : MonoBehaviour {

	public void SaveLevel(){
		PlayerPrefs.SetInt ("scene", SceneManager.GetActiveScene().buildIndex);
	}
}

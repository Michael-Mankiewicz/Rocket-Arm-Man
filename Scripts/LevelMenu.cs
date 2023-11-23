using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour {

	public TMP_Text num;
	private Color closedColor = new Color (1f, 1f, 1f, 0.5f);
	private Color normalColor = new Color (1f, 1f, 1f, 1f);

	// Use this for initializations
	void Start () {
		//print("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + "maxLevel: " + PlayerPrefs.GetInt("maxLevel"));
		/*if(PlayerPrefs.GetInt("currentLevel", 1) > PlayerPrefs.GetInt("maxLevel", 1)){
			num.SetText (PlayerPrefs.GetInt("maxLevel", 1).ToString());
			num.color = closedColor;
		} else {
			num.SetText (PlayerPrefs.GetInt("currentLevel", 1).ToString());
			num.color = normalColor;
		}*/
		num.SetText (PlayerPrefs.GetInt("currentLevel", 1).ToString());
		
		if(PlayerPrefs.GetInt("currentLevel", 1) > PlayerPrefs.GetInt("maxLevel", 1)){
			num.color = closedColor;
		} else {
			num.color = normalColor;
		}

	}
	
	public void IncreaseLevel(){
		if(PlayerPrefs.GetInt("currentLevel",1) < SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel",1) + 1);
		}

		num.SetText (PlayerPrefs.GetInt("currentLevel",1).ToString());

		if (PlayerPrefs.GetInt ("currentLevel",1) > PlayerPrefs.GetInt ("maxLevel",1)) {	
			num.color = closedColor;
		} else {
			num.color = normalColor;
		}
		//print("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + "maxLevel: " + PlayerPrefs.GetInt("maxLevel"));
	}
	public void DecreaseLevel(){
		if(PlayerPrefs.GetInt("currentLevel",1) > 1){
			PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel",1) - 1);
		}

		num.SetText (PlayerPrefs.GetInt("currentLevel",1).ToString());

		if (PlayerPrefs.GetInt ("currentLevel",1) > PlayerPrefs.GetInt ("maxLevel",1)) {	
			num.color = closedColor;
		} else {
			num.color = normalColor;
		}
		//print("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + "maxLevel: " + PlayerPrefs.GetInt("maxLevel"));
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void Start(){
		/*if(Application.isEditor == false){
			if(PlayerPrefs.GetInt("FirstPlay", 1) == 1){
				//firstPlay = true;
				PlayerPrefs.SetInt("FirstPlay", 0);
				//PlayerPrefs.Save();
				PlayerPrefs.DeleteAll();
			}
		}*/
		/*if(PlayerPrefs.GetInt("FirstPlay", 1) == 1){
				//firstPlay = true;
			PlayerPrefs.SetInt("FirstPlay", 0);
				//PlayerPrefs.Save();
			PlayerPrefs.DeleteAll();
		}*/
		//Screen.SetResolution(1920, 1080, true);
		/*
		PlayerPrefs.GetString("Pause")
		PlayerPrefs.GetString("Right")) ;
	    PlayerPrefs.GetString("Left")) ;
		PlayerPrefs.GetString("Jump")) ;
		PlayerPrefs.GetString("Reset")) ;
		PlayerPrefs.GetString("Continue")
		 */

		//PlayerPrefs.DeleteAll();

		if(PlayerPrefs.GetString("Pause") == ""){
			PlayerPrefs.SetString("Pause", "Escape");
		}
		if(PlayerPrefs.GetString("Right") == ""){
			PlayerPrefs.SetString("Right", "D");
		}
		if(PlayerPrefs.GetString("Left") == ""){
			PlayerPrefs.SetString("Left", "A");
		}
		if(PlayerPrefs.GetString("Jump") == ""){
			PlayerPrefs.SetString("Jump", "Space");
		}
		if(PlayerPrefs.GetString("Reset") == ""){
			PlayerPrefs.SetString("Reset", "R");
		}
		if(PlayerPrefs.GetString("Continue") == ""){
			PlayerPrefs.SetString("Continue", "LeftShift");
		}
		PlayerPrefs.SetInt("1PlayedOnce", 0);
		PlayerPrefs.SetInt("2PlayedOnce", 0);
		PlayerPrefs.SetInt("3PlayedOnce", 0);
		PlayerPrefs.SetInt("4PlayedOnce", 0);
		PlayerPrefs.SetInt("5PlayedOnce", 0);
		PlayerPrefs.SetInt("6PlayedOnce", 0);
		PlayerPrefs.SetInt("7PlayedOnce", 0);
		PlayerPrefs.SetInt("8PlayedOnce", 0);
		PlayerPrefs.SetInt("9PlayedOnce", 0);
		PlayerPrefs.SetInt("10PlayedOnce", 0);
		PlayerPrefs.SetInt("11PlayedOnce", 0);
		PlayerPrefs.SetInt("12PlayedOnce", 0);
		PlayerPrefs.SetInt("13PlayedOnce", 0);
		PlayerPrefs.SetInt("14PlayedOnce", 0);
		PlayerPrefs.SetInt("15PlayedOnce", 0);
		PlayerPrefs.SetInt("16PlayedOnce", 0);
		PlayerPrefs.SetInt("17PlayedOnce", 0);
		PlayerPrefs.SetInt("18PlayedOnce", 0);
		PlayerPrefs.SetInt("19PlayedOnce", 0);
		PlayerPrefs.SetInt("20PlayedOnce", 0);		
	}
	public void PlayGame(){
		/*if(PlayerPrefs.GetInt("currentLevel", 1 ) == 0){
			PlayerPrefs.SetInt("currentLevel", 1);
		} */
		/*if(PlayerPrefs.GetInt("currentLevel", 1) > PlayerPrefs.GetInt("maxLevel", 1))
		PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("maxLevel",1));*/
		if(PlayerPrefs.GetInt("currentLevel", 1) > PlayerPrefs.GetInt("maxLevel", 1)){
			SceneManager.LoadScene (PlayerPrefs.GetInt("maxLevel", 1));
		} else {
			SceneManager.LoadScene (PlayerPrefs.GetInt("currentLevel", 1));
		}
		
		StaticThings.GameIsPaused = false;
	}
	public void QuitGame(){
		Application.Quit ();
	}

}

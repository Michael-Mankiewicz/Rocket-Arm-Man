using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {


	public GameObject pauseMenuUI;
	public GameObject[] other;
	private KeyCode pause;
	float startTime = 0f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		pause = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pause")) ;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (pause) && Time.time - startTime > 0.75f) {
			if (StaticThings.GameIsPaused) {
				Resume ();
			} else {
				Pause();
			}

		}
	}
	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		StaticThings.GameIsPaused = false;
		foreach(GameObject obj in other)
			obj.SetActive(true);
	}
	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		StaticThings.GameIsPaused = true;
		foreach(GameObject obj in other)
			obj.SetActive(false);
	}
	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
		/*foreach(GameObject obj in other)
			obj.SetActive(true);*/
	}
	public void QuitGame(){
		StaticThings.firstTimePlayingLevel = true;
		Application.Quit ();
		foreach(GameObject obj in other)
			obj.SetActive(true);
	}
}

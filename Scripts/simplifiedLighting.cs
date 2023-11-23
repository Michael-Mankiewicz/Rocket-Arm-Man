using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class simplifiedLighting : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GameObject.Find("Camera/Main Camera").GetComponent<Camera>().backgroundColor = new Color(0f,1f,0f,1f);
		if(PlayerPrefs.GetInt("simpleLight") == 1){
			if(gameObject.GetComponent<Light>() != null){
				gameObject.GetComponent<Light>().enabled = false;
			}
			if(gameObject.GetComponent<SpriteRenderer>() != null){
				gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Standard");
			}
			if(gameObject.GetComponent<Grid>() != null){
				for(int i = 0; i < gameObject.transform.childCount; i++){
					if(gameObject.transform.GetChild(i).GetComponent<TilemapRenderer>() != null)
					gameObject.transform.GetChild(i).GetComponent<TilemapRenderer>().material = Resources.Load<Material>("Standard");
				}
			}
		} else {
			if(gameObject.GetComponent<Light>() != null){
				gameObject.GetComponent<Light>().enabled = true;
			}
			if(gameObject.GetComponent<SpriteRenderer>() != null){
				gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("solid object");
			}
			if(gameObject.GetComponent<Grid>() != null){
				for(int i = 0; i < gameObject.transform.childCount; i++){
					if(gameObject.transform.GetChild(i).GetComponent<TilemapRenderer>() != null)
					gameObject.transform.GetChild(i).GetComponent<TilemapRenderer>().material = Resources.Load<Material>("solid object");
				}
			}
		}

		if(StaticThings.backgroundGreen){
			GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("greenscreen");
		} else {
			if(PlayerPrefs.GetInt("simpleLight") == 1)
				GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("Standard");
			if(PlayerPrefs.GetInt("simpleLight") != 1)
				GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("solid object");
		}

		if(StaticThings.foregroundGreen){
			GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("greenscreen");
		} else {
			if(PlayerPrefs.GetInt("simpleLight") == 1)
				GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("Standard");
			if(PlayerPrefs.GetInt("simpleLight") != 1)
				GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("solid object");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Keypad5)){
			StaticThings.backgroundGreen = !StaticThings.backgroundGreen;
		}
		if(Input.GetKeyDown(KeyCode.Keypad6)){
			StaticThings.foregroundGreen = !StaticThings.foregroundGreen;
		}

		if(StaticThings.backgroundGreen){
			GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("greenscreen");
		} else {
			if(PlayerPrefs.GetInt("simpleLight") == 1)
				GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("Standard");
			if(PlayerPrefs.GetInt("simpleLight") != 1)
				GameObject.Find("Grid/Background").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("solid object");
		}

		if(StaticThings.foregroundGreen){
			GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("greenscreen");
		} else {
			if(PlayerPrefs.GetInt("simpleLight") == 1)
				GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("Standard");
			if(PlayerPrefs.GetInt("simpleLight") != 1)
				GameObject.Find("Grid/Foreground").GetComponent<TilemapRenderer>().material = Resources.Load<Material>("solid object");
		}
		
		}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class OptionsMenu : MonoBehaviour {


	Resolution[] resolutions;
	public AudioMixer audioMixer;
	public TMP_Dropdown resolutionDropdown;
	//public TMP_Dropdown graphicsDropdown;
	//public TMP_Dropdown goreDropdown;
	public Toggle fullScreenToggle;
	public Toggle goodLightingToggle;
	public Toggle goodCameraToggle;

	public Toggle dialogueToggle;
	public Toggle UIToggle;
	public Toggle infiniteToggle;
	public Slider volumeSlider;
	bool firstTime;
	bool firstPlay;
	//public List<string> rezs = new List<string> ();
	//public List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
	void Update(){
		//res.SetText("realres: " + Screen.width + " + " + Screen.height + " full: " + Screen.fullScreen + " Toggle: " + fullScreenToggle.isOn + "dropdown count: " + resolutionDropdown.options.Count);
		/*if (fullScreenToggle.isOn) {
			resolutionDropdown.interactable = false;
		} else {
			resolutionDropdown.interactable = true;
		}*/
	}
	void Start(){

		/*thyme = Time.time;
		//convert screen resolutions to a list of strings without refresh rate
		for(int i = 0; i < Screen.resolutions.Length; i++){
			string reza = Screen.resolutions[i].ToString();
			int at = reza.IndexOf("@");
			rezs.Add(reza.Remove(at));
			rezs[i].TrimEnd();			
		}
		//add only the unique resolutions to rezs
		rezs = rezs.Distinct().ToList();

		resolutionDropdown.ClearOptions ();

		int currentResolutionIndex = 0;
		
		//make current resolution index
		for(int i = 0; i < rezs.Count; i++){
			int w;
			int h;
			int.TryParse(rezs[i].Substring(0, rezs[i].IndexOf(" ")), out w);
			int.TryParse(rezs[i].Substring(rezs[i].LastIndexOf(" ") + 1, rezs[i].Substring(rezs[i].LastIndexOf(" ") + 1).Length), out h);
			
			if(Screen.width == w && Screen.height == h){
				currentResolutionIndex = i;
			}
			options.Add(new TMP_Dropdown.OptionData(rezs[i]));
		}
		
		//List<TMP_Dropdown.OptionData> options = rezs;
		//assigned dropmenu options to the options arraylist
		//resolutionDropdown.AddOptions (options);
		
		//updates the value of the dropdownmenu to the current resolution
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();
		*/
		if(PlayerPrefs.GetInt("simpleLight") == 0){
			goodLightingToggle.isOn = false;
		} else{
			goodLightingToggle.isOn = true;
		}

		if(PlayerPrefs.GetInt("simpleCameraEffects") == 0){
			goodCameraToggle.isOn = true;
		} else{
			goodCameraToggle.isOn = false;
		}
		if(Screen.fullScreen){
			fullScreenToggle.isOn = true;
		} else {
			fullScreenToggle.isOn = false;
		}
			
		if(PlayerPrefs.GetInt("dialogue") == 0){
			dialogueToggle.isOn = true;
		} else{
			dialogueToggle.isOn = false;
		}

		if(PlayerPrefs.GetInt("UI") == 0){
			UIToggle.isOn = true;
		} else{
			UIToggle.isOn = false;
		}
		
		if(PlayerPrefs.GetInt("infinite") == 0){
			infiniteToggle.isOn = false;
		} else{
			infiniteToggle.isOn = true;
		}	
		volumeSlider.value = PlayerPrefs.GetFloat("volume");
		audioMixer.SetFloat ("volume", PlayerPrefs.GetFloat("volume"));
		
}
		
	public void SetGoreValue(int value){
		StaticThings.goreValue = value;
	}
	public void SetVolume (float volume){
		audioMixer.SetFloat ("volume", volume);
		PlayerPrefs.SetFloat("volume", volume);
		StaticThings.volume = volume;
		PlayerPrefs.Save();
	}

	public void SetQuality (int qualityIndex){
		QualitySettings.SetQualityLevel (qualityIndex);
	}
	public void SetFullscreen(bool isFullscreen){
		//print("changed fullscreen"); 
	//	SetResolution(resolutionDropdown.value);
		Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.width, isFullscreen);
		/*if(isFullscreen){
			PlayerPrefs.SetInt("fullscreen", 1);	
		} else {
			PlayerPrefs.SetInt("fullscreen", 0);
		}*/
	}
	public void SetResolution(int resolutionIndex){
		//print("changed res");
		/*int w;
		int h;
		int.TryParse(rezs[resolutionIndex].Substring(0, rezs[resolutionIndex].IndexOf(" ")), out w);
		int.TryParse(rezs[resolutionIndex].Substring(rezs[resolutionIndex].LastIndexOf(" ") + 1, rezs[resolutionIndex].Substring(rezs[resolutionIndex].LastIndexOf(" ") + 1).Length), out h);
		
		Screen.SetResolution (w, h, fullScreenToggle.isOn);*/
		Screen.SetResolution(1920, 1080, fullScreenToggle.isOn);
	}
	public void Reset(){
		PlayerPrefs.SetInt("deaths", 0);
		PlayerPrefs.SetInt ("maxLevel", 1);
		PlayerPrefs.SetInt ("currentLevel", 1);
	}
	public void ChangeLighting(bool bad){
		if(bad){
			PlayerPrefs.SetInt("simpleLight", 1);
		} else {
			PlayerPrefs.SetInt("simpleLight", 0);
		}
		PlayerPrefs.Save();
	}
	public void ToggleDialogue(bool toggle){
		if(toggle){
			PlayerPrefs.SetInt("dialogue", 0);
		} else {
			PlayerPrefs.SetInt("dialogue", 1);
		}
		PlayerPrefs.Save();
	}
	public void ToggleUI(bool toggle){
		if(toggle){
			PlayerPrefs.SetInt("UI", 0);
		} else {
			PlayerPrefs.SetInt("UI", 1);
		}
		PlayerPrefs.Save();
	}
	public void ToggleInfiniteArms(bool toggle){
		if(toggle){
			PlayerPrefs.SetInt("infinite", 1);
		} else {
			PlayerPrefs.SetInt("infinite", 0);
		}
		PlayerPrefs.Save();
	}
	public void ChangeFX(bool good){
		if(good){
			PlayerPrefs.SetInt("simpleCameraEffects", 0);
		} else {
			PlayerPrefs.SetInt("simpleCameraEffects", 1);
		}
		PlayerPrefs.Save();
	}
}

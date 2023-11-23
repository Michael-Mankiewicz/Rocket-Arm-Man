using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour {

	private TextMeshProUGUI tmp;

	// Use this for initialization
	void Awake () {
		tmp = GetComponent<TextMeshProUGUI>();
		if (PlayerPrefs.GetInt("deaths") <= 9) {
			tmp.SetText ("Test Subject: 000000" + PlayerPrefs.GetInt("deaths", 0) + "-A");
		} else if (PlayerPrefs.GetInt("deaths") <= 99 && PlayerPrefs.GetInt("deaths") >= 10 ) {
			tmp.SetText("Test Subject: 00000" + PlayerPrefs.GetInt("deaths") + "-B");
		} else if (PlayerPrefs.GetInt("deaths") <= 999 && PlayerPrefs.GetInt("deaths") >= 100 ) {
			tmp.SetText("Test Subject: 0000" + PlayerPrefs.GetInt("deaths") + "-C");
		} else if (PlayerPrefs.GetInt("deaths") <= 9999 && PlayerPrefs.GetInt("deaths") >= 1000 ) {
			tmp.SetText("Test Subject: 000" + PlayerPrefs.GetInt("deaths") + "-D");
		} else if (PlayerPrefs.GetInt("deaths") <= 99999 && PlayerPrefs.GetInt("deaths") >= 10000 ) {
			tmp.SetText("Test Subject: 00" + PlayerPrefs.GetInt("deaths") + "-E");
		} else if (PlayerPrefs.GetInt("deaths") <= 999999 && PlayerPrefs.GetInt("deaths") >= 100000 ) {
			tmp.SetText("Test Subject: 0" + PlayerPrefs.GetInt("deaths") + "-F");
		} 
		PlayerPrefs.SetString ("subject", tmp.text);
	
		if(PlayerPrefs.GetInt("UI") == 1){
			tmp.SetText ("");	
		}
	}

	// Update is called once per frame
	void Update () {
		

	}
}

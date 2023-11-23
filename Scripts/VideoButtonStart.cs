using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Sprites;

public class VideoButtonStart : MousePointer {

	public GameObject videoHolder;
	public GameObject[] otherThings;
	public VideoPlayer VP;
	private EventTrigger butt;
	private Button booty;

	void Start () {
		butt = transform.GetComponent<EventTrigger>();
		booty = transform.GetComponent<Button>();
	}

	public void PlayPicture() {

		videoHolder.SetActive(true);
		foreach(GameObject thing in otherThings){
			thing.SetActive(false);
		}
		butt.enabled = false;
		booty.enabled = false;

	}
	public void AntiPlayPicture() {

		videoHolder.SetActive(false);
		foreach(GameObject thing in otherThings){
			thing.SetActive(true);
		}
		butt.enabled = true;
		booty.enabled = true;
	}
}

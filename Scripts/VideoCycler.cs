using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoCycler : MousePointer {

	public GameObject[] Videos;
	public int currentVidIndex;
	public VideoClip[] actualVids;
	public VideoPlayer VP;
	public GameObject progress;
	public GameObject start;
	public GameObject end;
	private bool dragging = false;
	
	void Start () {
		currentVidIndex = PlayerPrefs.GetInt("currentVideoIndex", 0);
		Videos[currentVidIndex].SetActive(true);
		VP.clip = actualVids[currentVidIndex];
		progress.transform.position = new Vector3(start.transform.position.x, progress.transform.position.y, 0);
	}
	void Update(){
		ProgressBar();
	}
	void ProgressBar(){
		if(Input.GetMouseButtonDown(0) && Vector3.Distance(progress.transform.position, cursorPos) < 1.5f ){
			dragging = true;	
		}
		if(Input.GetMouseButtonUp(0))
			dragging = false;
		if(VP.frameCount > 0 && !dragging){
			progress.transform.position = new Vector3(start.transform.position.x + ((float)VP.frame / (float)VP.frameCount) * (Vector3.Distance(start.transform.position, end.transform.position)), progress.transform.position.y, 0);
		} else {
			if(cursorPos.x < start.transform.position.x)
				progress.transform.position = new Vector3(start.transform.position.x, progress.transform.position.y, 0);
			if(cursorPos.x > end.transform.position.x)
				progress.transform.position = new Vector3(end.transform.position.x, progress.transform.position.y, 0);
			if(cursorPos.x < end.transform.position.x && cursorPos.x > start.transform.position.x)
				progress.transform.position = new Vector3(cursorPos.x, progress.transform.position.y, 0);
			VP.frame = (long)(((progress.transform.position.x - start.transform.position.x)/(end.transform.position.x-start.transform.position.x))* VP.frameCount);
		}
	}

	public void MoveRight(){
		Videos[currentVidIndex].SetActive(false);
		if(currentVidIndex < Videos.Length - 1){
			currentVidIndex++;
		} else {
			currentVidIndex = 0;
		}
		VP.clip = actualVids[currentVidIndex];
		PlayerPrefs.SetInt("currentVideoIndex", currentVidIndex);
		Videos[currentVidIndex].SetActive(true);
	}
	public void MoveLeft(){
		Videos[currentVidIndex].SetActive(false);
		if(currentVidIndex > 0){
			currentVidIndex--;
		} else {
			currentVidIndex = Videos.Length - 1;
		}
		VP.clip = actualVids[currentVidIndex];
		PlayerPrefs.SetInt("currentVideoIndex", currentVidIndex);
		Videos[currentVidIndex].SetActive(true);
	}
}

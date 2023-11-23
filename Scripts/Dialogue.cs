 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Video;
//using UnityEditor;
public class Dialogue : MonoBehaviour {

	private int CS;
	public TMP_Text textBox;
	public TMP_Text continu;
	public TMP_Text title;
	//Store all your text in this string array
	private List<string> goatText = new List<string>();
	private KeyCode continyou;
	public AudioClip[] audioh;
	AudioClip clickClip;
	AudioSource[] _sources;
	public int currentlyDisplayingText = 1;
	bool x = false;
	bool y = false;
	public VideoPlayer vp;
	int time = 0;
	public GameObject[] everything;
	string subject;
	
	void Start(){
		dialogue();
	}

void dialogue(){
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			 _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;
             // set up the properties such as distance for 3d sounds here if you need to.
         }

		if (PlayerPrefs.GetInt("deaths") <= 9) {
			subject = "Test Subject: 000000" + PlayerPrefs.GetInt("deaths", 0) + "-A";
		} else if (PlayerPrefs.GetInt("deaths") <= 99 && PlayerPrefs.GetInt("deaths") >= 10 ) {
			subject = "Test Subject: 00000" + PlayerPrefs.GetInt("deaths") + "-B";
		} else if (PlayerPrefs.GetInt("deaths") <= 999 && PlayerPrefs.GetInt("deaths") >= 100 ) {
			subject = "Test Subject: 0000" + PlayerPrefs.GetInt("deaths") + "-C";
		} else if (PlayerPrefs.GetInt("deaths") <= 9999 && PlayerPrefs.GetInt("deaths") >= 1000 ) {
			subject = "Test Subject: 000" + PlayerPrefs.GetInt("deaths") + "-D";
		} else if (PlayerPrefs.GetInt("deaths") <= 99999 && PlayerPrefs.GetInt("deaths") >= 10000 ) {
			subject = "Test Subject: 00" + PlayerPrefs.GetInt("deaths") + "-E";
		} else if (PlayerPrefs.GetInt("deaths") <= 999999 && PlayerPrefs.GetInt("deaths") >= 100000 ) {
			subject = "Test Subject: 0" + PlayerPrefs.GetInt("deaths") + "-F";
		} 

		_sources[2].mute = false;
		_sources[3].mute = false;

		continyou = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Continue")) ;
		continu.SetText("Press " + PlayerPrefs.GetString("Continue") + " to Continue");
		
		title.enabled = true;
		continu.enabled = false;
		CS = SceneManager.GetActiveScene().buildIndex;
		switch (CS) {
		case 1:
			goatText = new List<string> (){"","Hello there " + subject + "! You have successfully survived the surgery and will be on your way to using your new powers!", "I will guide you throughout the learning process, but keep in mind you can always disable me or seek additional help from the main menu.", "Use " + PlayerPrefs.GetString("Left") + " and " + PlayerPrefs.GetString("Right") + " to walk around, " +
				"and press " + PlayerPrefs.GetString("Jump") + " to jump.", "Click and you'll notice one of your arms get painlessly blown off.","Press " + PlayerPrefs.GetString("Reset") + " to reset the level.","Through the miracles of science, you now have rocket arms!", "The explosions don't hurt you, so shoot the floor to go upwards and jump with the explosion if you want to move even higher.", "All we need you to do is reach the end of each level.","Good luck and stay scientific."};
			break;
		case 2:
			goatText = new List<string> (){"", "Here, we need you to make it over the pit.", "Run to the right, and while doing so, jump and blast " +
				"yourself to the right.", "If you have trouble seeing where the exit is, scroll to zoom out."};
			break;
		case 3:
			goatText = new List<string> (){"", "You will notice there is nowhere to go but up, just like my life.", "Fling yourself onto one of the " +
				"walls and, while sliding on the wall, shoot another arm slightly below you.", "You should be able to find yourself landing on the exit," +
				" but sadly I'll never land a better job than this."};
			break;
		case 4:
			goatText = new List<string> (){"", "This room is supposed to present a combination of the last two rooms,", "but if you weren't alive for" +
				" those I wish you luck."};
			break;
		case 5:
			goatText = new List<string> (){"", "Have you ever seen a boomerang?", "Do that.", "Basically, stop your momentum by slapping the wall and then blast off of it with a rocket."};
			break;
		case 6:
			goatText = new List<string> (){"", "For this test we attached four more arms to your body, bringing your arm count to a total of 6.",
				"It's not because we want to make your life easier;", "it's because you'll need them."};
			break;
		case 7:
			goatText = new List<string> (){"", "It's about time you were exposed to more complicated rooms like this one.", "But as you explore it, avoid the deadly lasers, please.",
			"It's annoying having to carry so many dead bodies out of the test chambers; we are running out of places to put them.", "I have piles of them in my backyard and they smell really bad."};
			break;
		case 8:
			goatText = new List<string> (){"", "When you try to make the jump normally, you'll notice you can't.",
				"Use the ceiling to gain speed."};
			break;
		case 9:
			goatText = new List<string> (){"", "Although lasers may kill you, your arms can pass through them just fine.",
				"Use this to your advantage and use your explosions like a pogo stick.", "Jump at first, and then shoot underneath you and slightly behind you so you hover above the lasers while also moving forwards."};
			break;
		case 10:
			goatText = new List<string> (){"", "As you speed up you need to gradually aim more forward to compensate for the speed of your rocket arms.", "So, uh, do the last thing but for longer." };
			break;
		case 11:
			goatText = new List<string> (){"", "You're getting better at this, right?", "When you make a jump before the pit, create an explosion that is directly beneath you.", "That means moving your cursor slightly more to the right while you are pogoing,","or panicking and spamming all of the arms you have left."};
			break;
		case 12:
			goatText = new List<string> (){"", "If you zoom out, you'll notice a button on the ceiling.", "All of the buttons in a given chamber must be activated for its exit to be enabled, and only the power of an explosion can press a button."};
			break;
		case 13:
			goatText = new List<string> (){"", "Is this a cRoSsOvRr EpIsOdE?",
				"There are both buttons and lasers in the room.", "Give yourself as much airtime as you can."};
			break;
		case 14:
			goatText = new List<string> (){"", "Don't touch anything.",
				"You'll need to rely on your skills of wall jumping and pogoing.", "I recommend you shoot off of the right wall first, then use the left wall to start pogoing to the right."};
			break;
		case 15:
			goatText = new List<string> (){"", "Sweety, I need you to get out of my house and get a real job. I need my closet but you're always reading lines all day in here. You're pushing 30, mooching off of your hardworking parents, and starting to dissapoint me and your father.",
				"...did you hear that? Um, damn it, I can't afford another retake. Anyways, just imagine you're a threading a needle or something and flick your mouse up and down to shoot both buttons while you are in the air.", "I SWEAR, I BROUGHT YOU IN THIS WORLD AND I COULD TAKE YOU OUT OF IT!"};
			break;
		case 16:
			goatText = new List<string> (){"", "Hey, look man, I know that you might not be the same test subject as the last guy, but I love you man.",
				"I feel like we grew a bond, you know?", "I feel I owe you an apology for what happened in the last chamber.", "My mom could be a total douche sometimes, you feel me?", "Please survive this one and try to take it slowly if you can.", "It's like the last chamber but with lasers and giant pit."};
			break;
		case 17:
			goatText = new List<string> (){"", "Normal wall jumping won't cut it in this level.",
				"For the first two walls, shoot two rockets on the wall you want to bounce off of."};
			break;
		case 18:
			goatText = new List<string> (){"", "I'm sure you could figure this out on your own, except for avoiding the laser near the exit.",
				"You'll need to reverse wall jump, basically.", "Slow your descent by hugging a wall and shooting rockets beneath you on the wall.", "If you think this is tough then you better worry for the next level."};
			break;
		case 19:
			goatText = new List<string> (){"", "Get pranked, loser.",
				"It's actually the next level you need to worry about."};
			break;
		case 20:
			goatText = new List<string> (){"", "We stuffed fifty arms into your body, which is far more than the most you've ever had at once, and you'll need every last one of them.",
				"Reverse wall jumping, pogoing, buttons, normal wall jumping, and horizontal jumping- this level has everything.", "Rinse and repeat, and good luck."};
			break;

		}
		if(PlayerPrefs.GetInt("dialogue") == 0){
			if(PlayerPrefs.GetInt("1PlayedOnce") == 0 && CS == 1){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("2PlayedOnce") == 0 && CS == 2){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("3PlayedOnce") == 0 && CS == 3){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("4PlayedOnce") == 0 && CS == 4){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("5PlayedOnce") == 0 && CS == 5){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("6PlayedOnce") == 0 && CS == 6){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("7PlayedOnce") == 0 && CS == 7){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("8PlayedOnce") == 0 && CS == 8){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("9PlayedOnce") == 0 && CS == 9){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("10PlayedOnce") == 0 && CS == 10){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("11PlayedOnce") == 0 && CS == 11){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("12PlayedOnce") == 0 && CS == 12){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("13PlayedOnce") == 0 && CS == 13){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("14PlayedOnce") == 0 && CS == 14){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("15PlayedOnce") == 0 && CS == 15){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("16PlayedOnce") == 0 && CS == 16){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("17PlayedOnce") == 0 && CS == 17){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("18PlayedOnce") == 0 && CS == 18){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("19PlayedOnce") == 0 && CS == 19){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} else if(PlayerPrefs.GetInt("20PlayedOnce") == 0 && CS == 20){
				StartCoroutine(AnimateText());
				title.SetText("Mr. Scientist");
			} 
		}
}
		
	//This is a function for a button you press to skip to the next text
	public void SkipToNextText(){
		StopAllCoroutines();
		if (currentlyDisplayingText == goatText.Count - 1) {
			currentlyDisplayingText = 0;
			_sources[2].mute = true;
			_sources[3].mute = true;
			_sources[4].Play();

			if(CS == 1){
				PlayerPrefs.SetInt("1PlayedOnce", 1);
			} else if(CS == 2){
				PlayerPrefs.SetInt("2PlayedOnce", 1);
			} else if(CS == 3){
				PlayerPrefs.SetInt("3PlayedOnce", 1);
			} else if(CS == 4){
				PlayerPrefs.SetInt("4PlayedOnce", 1);
			} else if(CS == 5){
				PlayerPrefs.SetInt("5PlayedOnce", 1);
			} else if(CS == 6){
				PlayerPrefs.SetInt("6PlayedOnce", 1);
			} else if(CS == 7){
				PlayerPrefs.SetInt("7PlayedOnce", 1);
			} else if(CS == 8){
				PlayerPrefs.SetInt("8PlayedOnce", 1);
			} else if(CS == 9){
				PlayerPrefs.SetInt("9PlayedOnce", 1);
			} else if(CS == 10){
				PlayerPrefs.SetInt("10PlayedOnce", 1);
			} else if(CS == 11){
				PlayerPrefs.SetInt("11PlayedOnce", 1);
			} else if(CS == 12){
				PlayerPrefs.SetInt("12PlayedOnce", 1);
			} else if(CS == 13){
				PlayerPrefs.SetInt("13PlayedOnce", 1);
			} else if(CS == 14){
				PlayerPrefs.SetInt("14PlayedOnce", 1);
			} else if(CS == 15){
				PlayerPrefs.SetInt("15PlayedOnce", 1);
			} else if(CS == 16){
				PlayerPrefs.SetInt("16PlayedOnce", 1);
			} else if(CS == 17){
				PlayerPrefs.SetInt("17PlayedOnce", 1);
			} else if(CS == 18){
				PlayerPrefs.SetInt("18PlayedOnce", 1);
			} else if(CS == 19){
				PlayerPrefs.SetInt("19PlayedOnce", 1);
			} else if(CS == 20){
				PlayerPrefs.SetInt("20PlayedOnce", 1);
			}
		} else if (currentlyDisplayingText >= 1) {
			currentlyDisplayingText++;
		} 
		//If we've reached the end of the array, do anything you want. I just restart the example text
		StartCoroutine(AnimateText());
	} 
	//Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every 0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
	IEnumerator AnimateText(){
		for (int i = 0; i < goatText[currentlyDisplayingText].Length + 1; i++)
		{
			if(i == 0 && currentlyDisplayingText == 1){
				_sources[2].Play();
				x = true;
			}
			textBox.SetText(goatText[currentlyDisplayingText].Substring(0, i));
				/*int index = UnityEngine.Random.Range (5, 14);
				float chance = UnityEngine.Random.Range (0.9f, 1.1f);
				float maybe = UnityEngine.Random.Range (0f, 1f);
				_sources[index].pitch = UnityEngine.Random.Range (0.9f, 1.1f);
				if( _sources[5].isPlaying == false && _sources[6].isPlaying == false && _sources[7].isPlaying == false &&
				 _sources[8].isPlaying == false && _sources[9].isPlaying == false && _sources[10].isPlaying == false && _sources[11].isPlaying == false&& _sources[12].isPlaying == false&&
				 _sources[13].isPlaying == false&& _sources[14].isPlaying == false&& currentlyDisplayingText != 0){
					_sources[index].pitch = chance;
				}*/
				
			yield return new WaitForSeconds(.03f);
		}
		if (currentlyDisplayingText != 0) {
			continu.enabled = true;
		} else {
			title.enabled = false;
		}
	}

	void Update(){
       

		if(_sources[2].isPlaying == false && _sources[3].loop == false && x == true){
			_sources[3].loop = true;
			_sources[3].Play();
		} else if (_sources[4].isPlaying == true){
			_sources[3].mute = true;
		}
		if(PlayerPrefs.GetInt("dialogue") == 0){
		if (Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("1PlayedOnce") == 0 && CS == 1) {
			SkipToNextText ();
			continu.enabled = false;		
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("2PlayedOnce") == 0 && CS == 2) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("3PlayedOnce") == 0 && CS == 3) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("4PlayedOnce") == 0 && CS == 4) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("5PlayedOnce") == 0 && CS == 5) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("6PlayedOnce") == 0 && CS == 6) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("7PlayedOnce") == 0 && CS == 7) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("8PlayedOnce") == 0 && CS == 8) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("9PlayedOnce") == 0 && CS == 9) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("10PlayedOnce") == 0 && CS ==10) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("11PlayedOnce") == 0 && CS == 11) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("12PlayedOnce") == 0 && CS == 12) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("13PlayedOnce") == 0 && CS == 13) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("14PlayedOnce") == 0 && CS == 14) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("15PlayedOnce") == 0 && CS == 15) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("16PlayedOnce") == 0 && CS == 16) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("17PlayedOnce") == 0 && CS == 17) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("18PlayedOnce") == 0 && CS == 18) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("19PlayedOnce") == 0 && CS == 19) {
			SkipToNextText ();
			continu.enabled = false;
		} else if(Input.GetKeyDown(continyou) && PlayerPrefs.GetInt("20PlayedOnce") == 0 && CS == 20) {
			SkipToNextText ();
			continu.enabled = false;
		}
		}
	}

}

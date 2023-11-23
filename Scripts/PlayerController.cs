using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
//using UnityEditor;
public class PlayerController : MonoBehaviour {
	
	float lrd;
	float lrs;
	public float lrSpeed;

	BoxCollider2D collider;
	SpriteRenderer sr;
	Rigidbody2D rb;
	Animator animator;

	public float fireSpeed;

	[Space(10)]
	[Header("Arms")]
	public ArmHolder armHolder;
	[Space(10)]

	[Space(10)]
	[Header("Sound")]
	public AudioClip[] audioh;
	public AudioSource[] _sources;
	// Use this for initialization
	int index = 0;

	[Space(10)]

	[Space(10)]
	[Header("Explosion")]
	public float mag;
	public float roughness;
	public float inTime;
	public float outTime;
	CameraShakeInstance shake;
	[Space(10)]

	[Space(10)]
	[Header("Movement")]
	public float jSpeed;
	public bool onGround;
	public Transform groundCheck;
	public LayerMask groundLayer;
	public float groundCheckRadius;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public float acceleration = 20f;
	public float maxVelocityX = 20f;
	public float Gacceleration = 100f;
	public float GmaxVelocityX = 20f;
	private float speed;
	private float platformSpeed;
	private Vector3 temp;
	public int delay = 10;
	public bool movingForward = true;
	public Flip flip;
	private KeyCode right, left, jump, reset;
	public AudioMixer audioMixer;
	 Dialogue dialogue;
	public bool onMovingPlatform;

	//public Transform spawnPoint;
	void OnCollision2DStay(Collider2D other){
		
		if (other.gameObject.tag == "Moving Platform") {
			transform.parent = other.transform;
			onMovingPlatform = true;
			platformSpeed = other.gameObject.GetComponent<MovingPlatform> ().speed;
		}
	}
	void OnCollision2DLeave(Collider2D other){
		if (other.gameObject.tag == "Moving Platform") {
			transform.parent = null;
			onMovingPlatform = false;
			platformSpeed = 0;
		}
	}


	void Start () {

		//spawnPoint = GameObject.Find("RAM spawn").transform;
		audioMixer.SetFloat ("volume", PlayerPrefs.GetFloat("volume"));
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			 _sources[i].spatialBlend = 0f;
			 _sources[i].volume = 0.25f;
			 _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;//((AudioMixerGroup)AssetDatabase.LoadAssetAtPath("Assets/Sound/NewAudioMixer.mixer", typeof(AudioMixerGroup)));
             // set up the properties such as distance for 3d sounds here if you need to.
         }
		_sources[3].spatialBlend = 0f;
		_sources[3].volume = 0.075f;

		right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right")) ;
		left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left")) ;
		jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump")) ;
		reset = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reset")) ;

		temp = transform.position;
		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
		animator = GetComponent<Animator>();
		dialogue = GameObject.Find("UI/Canvas").GetComponent<Dialogue>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Keypad1)){
			Time.timeScale = 1f;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
		if(Input.GetKeyDown(KeyCode.Keypad2)){
			Time.timeScale = 0.5f;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
		if(Input.GetKeyDown(KeyCode.Keypad3)){
			Time.timeScale = 0.25f;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
		if(Input.GetKeyDown(KeyCode.Keypad4)){
			Time.timeScale = 0.125f;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
		print(animator);
		/*if(transform.position != spawnPoint.position)
			StaticThings.justSpawned = false;*/
		animator.SetFloat ("speed", speed);


		//direction and speed in x axis
		if(Input.GetKey(right) && Input.GetKey(left)){
			lrd = 0;
		} else if (Input.GetKey(right)){
			lrd = 1;
		} else if (Input.GetKey(left)){
			lrd = -1;
		} else {
			lrd = 0;
		}
		
		lrs = lrd * lrSpeed;

		//check if on ground
		/*if (Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer) ||
		    Physics2D.OverlapCircle (new Vector3 (groundCheck.position.x - 0.3f - groundCheckRadius, groundCheck.position.y, groundCheck.position.z), groundCheckRadius, groundLayer) ||
		    Physics2D.OverlapCircle (new Vector3 (groundCheck.position.x + 0.5f + groundCheckRadius, groundCheck.position.y, groundCheck.position.z), groundCheckRadius, groundLayer)) {
			onGround = true;
		} else {
			onGround = false;
		}*/
		Physics2D.OverlapBox(groundCheck.position, new Vector2(collider.size.x, groundCheckRadius), 0f, groundLayer);
		/*if(Physics2D.OverlapBox(groundCheck.position, new Vector2(collider.size.x, groundCheckRadius), 0f, groundLayer)){
			onGround = true;
		} else {
			onGround = false;
		} */

		//check if moving forward
		if (lrd >= 0 && !flip.flipped) {
			movingForward = true;
		} else if (lrd <= 0 && flip.flipped) {
			movingForward = true;
		} else {
			movingForward = false;
		}
		animator.SetBool ("movingForward", movingForward);

		//jump
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKey (jump)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
		}
		if (Input.GetKeyDown(jump) && onGround) {
			rb.velocity +=  Vector2.up * jSpeed; 
		}

		//move player left right

		//if you are in the air
		if (onGround == false) {
			
				//strave right

				//if the absolute value of the x velocity is less than 20 or moving right will slow you down
			if (Mathf.Abs(rb.velocity.x) < maxVelocityX || Mathf.Abs (rb.velocity.x + 1f) < Mathf.Abs(rb.velocity.x)) {
					//if right arrow key or d is pressed
				if (lrd > 0) {
					rb.velocity = new Vector2 (rb.velocity.x + acceleration * Time.deltaTime, rb.velocity.y);

				} 
			}

				//strave left

				//if the absolute value of the x velocity is less than 20 or moving left will slow you down
			if (Mathf.Abs(rb.velocity.x) < maxVelocityX || Mathf.Abs (rb.velocity.x - 1f) < Mathf.Abs(rb.velocity.x)) {		 
					//if left arrow key or a is pressed
				if (lrd < 0) {
					rb.velocity = new Vector2 (rb.velocity.x - acceleration * Time.deltaTime, rb.velocity.y);

				}
			}
			
		} else {
			//move left right on ground
			if (Mathf.Abs(rb.velocity.x) < GmaxVelocityX || Mathf.Abs (rb.velocity.x + 1f) < Mathf.Abs(rb.velocity.x)) {
				//if right arrow key or d is pressed
				if (lrd > 0) {
					rb.velocity = new Vector2 (rb.velocity.x + Gacceleration * Time.deltaTime, rb.velocity.y);
				} 
			}

			//if the absolute value of the x velocity is less than 20 or moving left will slow you down
			if (Mathf.Abs(rb.velocity.x) < GmaxVelocityX || Mathf.Abs (rb.velocity.x - 1f) < Mathf.Abs(rb.velocity.x)) {		 
				//if left arrow key or a is pressed
				if (lrd < 0) {
					rb.velocity = new Vector2 (rb.velocity.x - Gacceleration * Time.deltaTime, rb.velocity.y);
				}
			}

		}

		if (Mathf.Abs (lrd) > 0 && speed < delay) {
			speed++;
		} else if (!onGround && speed < delay) {
			speed++;
		} else if(speed > 0) {
			speed--;
		}
			
		//shoot projectiles (when left click)
		if (Input.GetMouseButtonDown (0) && StaticThings.GameIsPaused == false) {
			
			if (armHolder.HasArms() && Time.timeSinceLevelLoad > 0.01f) {
				//shake screen
				shake = CameraShaker.Instance.ShakeOnce(mag,roughness,inTime,outTime);
				//play audio in an array at random
				float chance = Random.Range (0f, 1f);
				float chance2 = Random.Range (0f, 1f);
				 if(chance < 0.33f){
				 index = 0;
		 		} else if(chance < 0.66f){
				 index = 1;
		 		} else {
				 index = 2;
				}

				_sources[index].pitch = Random.Range (0.95f, 1.05f);
				if(chance2 < 0.15f || (dialogue.currentlyDisplayingText == 4 && SceneManager.GetActiveScene().buildIndex == 1))
					_sources[index].Play();

				_sources[3].pitch = Random.Range (0.8f, 1.2f) - 0.2f;
				_sources[3].Play();

				armHolder.Shoot (fireSpeed);

			}

		}
		//reload level
		if (Input.GetKeyDown (reset) && !StaticThings.GameIsPaused) {
			StaticThings.firstTimePlayingLevel = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			/*rb.velocity = Vector2.zero;
			transform.position = spawnPoint.position;
			StaticThings.justSpawned = true;*/
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		}
		/*
		if (SceneManager.GetActiveScene().buildIndex == 7 && transform.position.y < -100) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		} else if(SceneManager.GetActiveScene().buildIndex == 8 && transform.position.y < 25){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		} else if(SceneManager.GetActiveScene().buildIndex == 9 && transform.position.y < -75){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		} else if(transform.position.y < -25){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		} */

		temp = transform.position;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.GetComponent<MovingPlatform> () != null) {
			//transform.parent = coll.transform;


		}
		if(coll.gameObject.GetComponent<BoxCollider2D>().sharedMaterial == null){
			onGround = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.GetComponent<MovingPlatform> () != null) {
			//transform.parent = null;

		}
	if(coll.gameObject.GetComponent<BoxCollider2D>().sharedMaterial == null){
			onGround = false;
		}
	
	}
}

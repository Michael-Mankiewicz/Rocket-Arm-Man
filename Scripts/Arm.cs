using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEditor;
public class Arm : MonoBehaviour {

	public bool launched;
	public float explosionForce = 700f;
	public GameObject explosionEffect;
	public float blastRadius = 1f;
	bool hasExploded = false;
	private Rigidbody2D rb;
	private Vector3 childPos;
	private Vector3 direction;
	private ParticleSystem blood;
	private RaycastHit2D hit;
	public Vector3 launchPoint;
	public LayerMask layers;

	public AudioClip[] audioh;
	public AudioSource[] _sources;
	private Flip ManlyMan;
	private bool definitelyFlipped = false;
	// Use this for initialization
	float pitch = 1f;	

	Vector3 pos = Vector3.zero;
	public HingeJoint2D joint;
	//public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;
	IEnumerator Delete(){
		transform.position = new Vector3 (1000, 1000, 0);
		yield return new WaitForSeconds (10);
		Destroy (gameObject);
	}
	void OnGUI(){
				hit = Physics2D.Raycast (transform.position, (transform.GetChild (0).position- transform.position).normalized, 
			(transform.GetChild (0).position - transform.position).magnitude, layers );

		if (hit.collider != null) {
			if (launched && !hasExploded) {
				Explode (explosionForce * 1000, blastRadius);
				if(hit.collider.gameObject.GetComponent<Triggered> () != null ){
					if(hit.collider.gameObject.GetComponent<Triggered> ().triggered == false){
						hit.collider.gameObject.GetComponent<Triggered> ().triggered = true;
						hit.collider.gameObject.GetComponent<Triggered> ().anim.SetBool("triggered", true);
						hit.collider.gameObject.GetComponent<Triggered> ().Click();
					}
				}
				hasExploded = true;
			}
		}

		if (!launched) {
			launchPoint = transform.position;
			/*if (ManlyMan.flipped && definitelyFlipped == false) {
					transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, transform.localScale.z);
					definitelyFlipped = true;
			} else if(ManlyMan.flipped == false && definitelyFlipped == true){
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
					definitelyFlipped = true;
			}*/
		}
		//print(ManlyMan.flipped);
		//Debug.DrawLine (transform.position, transform.position + (transform.GetChild (0).position - transform.position).normalized * (transform.GetChild (0).position - transform.position).magnitude, Color.red);

	}
	void OnEnable(){
		//ManlyMan = transform.parent.parent.parent.GetComponent<Flip>();
		ManlyMan = GameObject.Find("Man 2").GetComponent<Flip>();
		//print(ManlyMan);
		if(Mathf.Abs (ManlyMan.rotz()) > 90){
			transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if (Mathf.Abs(ManlyMan.rotz()) < 90){
			transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}
				//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;
		xy.Raycast (cursor, out distance);
		//subtract cursor - arm position
		difference =  cursor.GetPoint(distance) - transform.position;
		//do trig to find the angle of the point on the unit circle and convert it to degrees
		rotzed = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		//if the arm didn't launch yet, set the angle of the arm to rotz
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotzed));
	}
	public float rotz(){
		return rotzed;
	}


	
	IEnumerator Boom(){
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
	void Start() {
		
		ManlyMan = GameObject.Find("Man 2").GetComponent<Flip>();
		//print(ManlyMan);
		if(Mathf.Abs (ManlyMan.rotz()) > 90 && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if (Mathf.Abs(ManlyMan.rotz()) < 90 && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}


		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;
		xy.Raycast (cursor, out distance);
		//subtract cursor - arm position
		difference =  cursor.GetPoint(distance) - transform.position;
		//do trig to find the angle of the point on the unit circle and convert it to degrees
		rotzed = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
	
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotzed));
		
		//print(ManlyMan);
		/*if (ManlyMan.isLeft) {
				transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if(ManlyMan.isRight) {
				transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}*/
			

		pitch = Random.Range (0.8f, 1.2f);
		_sources = new AudioSource[audioh.Length];

         for (int i = 0; i < audioh.Length; i++)
         {
             _sources[i] = gameObject.AddComponent<AudioSource>();
             _sources[i].clip = audioh[i];
			 _sources[i].outputAudioMixerGroup = GameObject.Find("Audio").GetComponent<AudioSource>().outputAudioMixerGroup;//((AudioMixerGroup)AssetDatabase.LoadAssetAtPath("Assets/Sound/NewAudioMixer.mixer", typeof(AudioMixerGroup)));
			  _sources[i].spatialBlend = 1f;
			  _sources[i].pitch = pitch;
			  _sources[i].minDistance = 20f;
			 _sources[i].maxDistance = 250f;
             // set up the properties such as distance for 3d sounds here if you need to.
         }

		if(this.name == "ArmFront(Clone)"){
			pos = new Vector3(-0.35f,1.77f, 0f);
		} else if(this.name == "ArmBack(Clone)"){
			pos = new Vector3(0.35f,1.77f, 0f);
		}

		//_sources[0].spatialBlend = 0f;
		//_sources[0].volume = 0.15f;
		joint = gameObject.GetComponent<HingeJoint2D> ();
		joint.connectedAnchor = new Vector2(pos.x, pos.y);	
		joint.connectedBody = transform.parent.parent.GetComponent<Rigidbody2D> ();
		
		launched = false;
		hasExploded = false;
		rb = GetComponent<Rigidbody2D> ();
		blood = transform.GetChild (1).GetComponent<ParticleSystem>();

	}
	void Update(){	
		if(Mathf.Abs (ManlyMan.rotz()) > 90 && !launched && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if (Mathf.Abs(ManlyMan.rotz()) < 90 && !launched && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}
				//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;
		xy.Raycast (cursor, out distance);
		//subtract cursor - arm position
		difference =  cursor.GetPoint(distance) - transform.position;
		//do trig to find the angle of the point on the unit circle and convert it to degrees
		rotzed = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		//if the arm didn't launch yet, set the angle of the arm to rotz
		if (!launched && StaticThings.GameIsPaused == false ) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotz ()));
		}
		//print(transform.rotation.z);
		/*if(StaticThings.justSpawned == true && transform.parent == null){
			GameObject.Destroy(gameObject);
		}*/
	}
	void LateUpdate(){
		/*if(Input.GetKeyDown(KeyCode.O)){
			print(this.name + ": " +transform.localScale);
		}*/
		
		if(Mathf.Abs (ManlyMan.rotz()) > 90 && !launched && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if (Mathf.Abs(ManlyMan.rotz()) < 90 && !launched && StaticThings.GameIsPaused == false){
			transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}

		/*if (ManlyMan.turnLeft) {
					transform.localScale = new Vector3 (-1, -1, transform.localScale.z);
		} else if(ManlyMan.turnRight){
					transform.localScale = new Vector3 (1, 1, transform.localScale.z);
		}*/

	//	if(_sources[0].isPlaying == false && launched){
	//		_sources[1].Play();
	//	}
	//	print(_sources[0].isPlaying);

		//(1 << LayerMask.NameToLayer ("Ground"))
		if (!launched && StaticThings.GameIsPaused == false && StaticThings.GameIsPaused == false ) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotz ()));
		}

	}

	void FixedUpdate(){
				hit = Physics2D.Raycast (transform.position, (transform.GetChild (0).position- transform.position).normalized, 
			(transform.GetChild (0).position - transform.position).magnitude, layers );

		if (hit.collider != null) {
			if (launched && !hasExploded) {
				Explode (explosionForce * 1000, blastRadius);
				if(hit.collider.gameObject.GetComponent<Triggered> () != null){
					hit.collider.gameObject.GetComponent<Triggered> ().triggered = true;
					hit.collider.gameObject.GetComponent<Triggered> ().anim.SetBool("triggered", true);
					hit.collider.gameObject.GetComponent<Triggered> ().Click();
				}
				hasExploded = true;
			}
		}

		if (!launched) {
			launchPoint = transform.position;
			/*if (ManlyMan.flipped && definitelyFlipped == false) {
					transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, transform.localScale.z);
					definitelyFlipped = true;
			} else if(ManlyMan.flipped == false && definitelyFlipped == true){
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
					definitelyFlipped = true;
			}*/
		}
		//print(ManlyMan.flipped);
		//Debug.DrawLine (transform.position, transform.position + (transform.GetChild (0).position - transform.position).normalized * (transform.GetChild (0).position - transform.position).magnitude, Color.red);

	}
	//this method launches the arm. it's called by the player controller
	public void Launch(float speed){
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotz ()));
		launched = true;
		joint.enabled = false;
		rb.gravityScale = 0;
		rb.freezeRotation = true;
		transform.parent = null;	
		rb.AddForce (speed * new Vector2(difference.normalized.x, difference.normalized.y));
		blood.gameObject.SetActive (true);
		launchPoint = transform.position;
	//	_sources[0].pitch = pitch - 0.2f;
		_sources[0].Play();
	//	_sources[1].Play();
		StartCoroutine (Boom ());

	}
		

	void Explode(float force, float radius){	
		Instantiate (explosionEffect, new Vector3(hit.point.x, hit.point.y, 0f), Quaternion.Euler(0f, 0f, Vector3.Angle(Vector3.zero, new Vector3(hit.normal.x, hit.normal.y, 0f))));

		Collider2D[] colliders = Physics2D.OverlapCircleAll(hit.point,  radius, (1 << LayerMask.NameToLayer("Person")) ); 

		foreach (Collider2D nearbyObject in colliders) {
			if (nearbyObject.CompareTag ("Man")) {
				Rigidbody2D rb2 = nearbyObject.GetComponent<Rigidbody2D> ();
				Transform t = nearbyObject.GetComponent<Transform> ();
				AddExplosionForce (rb2, force, hit.point, radius);
			}
		}
		_sources[0].mute = true;
		StartCoroutine (Delete ());
	}

	public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		Vector3 dir = body.transform.Find("Pos").position - expPosition;
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) {
			calc = 0;		
		}

		body.AddForce (dir.normalized * expForce * calc);
	}
}

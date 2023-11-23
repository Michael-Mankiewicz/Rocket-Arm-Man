using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

	public bool flipped = false;
	public bool turnLeft = false;
	public bool turnRight = false;
	private bool startedFlipped = false;
	private List<Arm> arms = new List<Arm>();
	public bool isLeft = false;
	public bool isRight = true;

	public HingeJoint2D joint;
	//public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;
	void Start(){

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

		if(Mathf.Abs (rotz()) > 90){
			isLeft = true;
			isRight = false;
		} else {
			isRight = true;
			isLeft = false;
		}
		Transform Body = transform.Find ("Body");

		/*for (int i = 0; i <= Body.childCount - 1; i++) {
			
			if (Body.GetChild (i).CompareTag ("Arm Spot Front")) {
				
				for(int k = 0; k <= Body.GetChild (i).childCount - 1; k++){
					if (Body.GetChild (i).GetChild(k).CompareTag ("Arm Front")) {
						arms.Add (Body.GetChild (i).GetChild(k).GetComponent<Arm>());

					}
				}
			}
			if (Body.GetChild (i).CompareTag ("Arm Spot Back")) {
				for(int k = 0; k <= Body.GetChild (i).childCount - 1; k++){
					if (Body.GetChild (i).GetChild(k).CompareTag ("Arm Back")) {
						arms.Add (Body.GetChild (i).GetChild(k).GetComponent<Arm>());

					}
				}
			}
		}*/
	}
	public void UpdateArmList(){
		//Transform Body = transform.Find ("Body");
		
		arms.Clear();

		if(flipped){
			startedFlipped = true;
		}

		/*for (int i = 0; i <= Body.childCount - 1; i++) {
			
			if (Body.GetChild (i).CompareTag ("Arm Spot Front")) {
				
				for(int k = 0; k <= Body.GetChild (i).childCount - 1; k++){
					if (Body.GetChild (i).GetChild(k).CompareTag ("Arm Front")) {
						arms.Add (Body.GetChild (i).GetChild(k).GetComponent<Arm>());

					}
				}
			}
			if (Body.GetChild (i).CompareTag ("Arm Spot Back")) {
				for(int k = 0; k <= Body.GetChild (i).childCount - 1; k++){
					if (Body.GetChild (i).GetChild(k).CompareTag ("Arm Back")) {
						arms.Add (Body.GetChild (i).GetChild(k).GetComponent<Arm>());

					}
				}
			}
		}*/
	}
	void Update() {

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

		if(Mathf.Abs (rotz()) > 90){
			isLeft = true;
			isRight = false;
		} else {
			isRight = true;
			isLeft = false;
		}	
		if (Mathf.Abs (rotz()) > 90 && flipped == false && StaticThings.GameIsPaused == false) {
			
			/*foreach (Arm arm in arms) {	
				
				if (arm.launched == false) {
					arm.transform.localScale = new Vector3 (-arm.transform.localScale.x, -arm.transform.localScale.y, arm.transform.localScale.z);
				}
			}*/
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			//transform.rotation = Quaternion.Euler (0f, 0f, -transform.rotation.z);
			flipped = true;
			turnLeft = true;
		} else {
			turnLeft = false;
		}
		if (Mathf.Abs(rotz()) < 90 && flipped && StaticThings.GameIsPaused == false) {
			/*foreach (Arm arm in arms) {	

				if (arm.launched == false) {
					arm.transform.localScale = new Vector3 (-arm.transform.localScale.x, -arm.transform.localScale.y, arm.transform.localScale.z);
				}
			}*/
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			//transform.rotation = Quaternion.Euler (0f, 0f, -transform.rotation.z);
			flipped = false;
			turnRight = true;
		} else {
			turnRight = false;
		}
		
	}
	public float rotz(){
		return rotzed;
	}
}

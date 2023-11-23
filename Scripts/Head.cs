using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

	public float headMovement = 40f;
	public Flip manFlip;
	public HingeJoint2D joint;
	//public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;


	void Update(){
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
		RotateHead ();
	}


	void RotateHead(){
		bool flipped = manFlip.flipped;

		if (!flipped && Mathf.Abs (rotzed) < 0f + headMovement && StaticThings.GameIsPaused == false)
			transform.rotation = Quaternion.Euler (0f, 0f, rotzed);
		else if (flipped && Mathf.Abs (rotzed) > 180 - headMovement && StaticThings.GameIsPaused == false) {
			transform.rotation = Quaternion.Euler (0f, 0f, rotzed - 180);
		} else if (rotzed > 0 && !StaticThings.GameIsPaused) {
			if(flipped)
				transform.rotation = Quaternion.Euler (0f, 0f, headMovement - 90 );
			else 
				transform.rotation = Quaternion.Euler (0f, 0f, headMovement);		
		} else if (rotzed < 0 && !StaticThings.GameIsPaused) {
			if(flipped)
				transform.rotation = Quaternion.Euler (0f, 0f, headMovement);
			else 
				transform.rotation = Quaternion.Euler (0f, 0f, -headMovement);		
		}
	}

	void Start(){
		
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

		RotateHead ();
	}
		

}

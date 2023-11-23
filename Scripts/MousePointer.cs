using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour {

	public HingeJoint2D joint;
	public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;
	public Vector3 cursorPos;
	void Awake () {
		joint = GetComponent<HingeJoint2D> ();
		rb = GetComponent<Rigidbody2D> ();
				//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
	
		//find distance from start of ray to point of intersection with plane
		float distance;
		xy.Raycast (cursor, out distance);
		
		cursorPos = cursor.GetPoint(distance);
		//subtract cursor - arm position
		difference =  cursor.GetPoint(distance) - transform.position;
		//do trig to find the angle of the point on the unit circle and convert it to degrees
		rotzed = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		//if the arm didn't launch yet, set the angle of the arm to rotz
	}
	void FixedUpdate(){
		//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;
		xy.Raycast (cursor, out distance);

		cursorPos = cursor.GetPoint(distance);
		//subtract cursor - arm position
		difference =  cursor.GetPoint(distance) - transform.position;
		//do trig to find the angle of the point on the unit circle and convert it to degrees
		rotzed = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		//if the arm didn't launch yet, set the angle of the arm to rotz
	}
	public float rotz(){
		return rotzed;
	}
}

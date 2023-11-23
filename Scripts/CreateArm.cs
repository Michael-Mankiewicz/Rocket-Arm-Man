using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArm : MonoBehaviour {
	// Use this for initialization

	
	public HingeJoint2D joint;
	//public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeArm(Transform arm, Vector3 pos){
				//creating an infinite plane
	/*	Plane xy = new Plane(Vector3.back, Vector3.zero);
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
		print(rotzed);*/
		//Vector3 pos = Vector3.zero;
		//print(transform.name + ": " + transform.position transform.parent.parent.localPosition  - transform.position+ transform.parent.parent.parent.name + ": " + transform.parent.parent.parent.localPosition);
		
		
		Instantiate (arm, pos, Quaternion.identity, transform.parent.parent);
	}
}

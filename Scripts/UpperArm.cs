using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperArm : MonoBehaviour {

	public int offset ;
	public float smoothSpeed = 0.125f;
	public float rotz;
	public Transform lowerArm;
	public Arm arm;
	private Rigidbody2D rb;
	public Rigidbody2D weight;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		weight = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate(){

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0f, 0f, rotz + offset), smoothSpeed);

	}

	void Update () {
		//if(Physics.Raycast(transform.position,(lowerArm.position-transform.position).Normalize(),(lowerArm.position-transform.position).magnitude()){
			
	//	}
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize ();
		rotz = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
	}

}

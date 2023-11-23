using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorFollow : MonoBehaviour {
	public float sensitivity;
	float rotZ2;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		rotZ2 = 0;
	}
	
	// Update is called once per frame
	void Update(){
		//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;

		xy.Raycast (cursor, out distance);

		Vector2 cursorPos = cursor.GetPoint(distance);
		float speed = Mathf.Abs(transform.position.x - cursorPos.x);
		int posOrNeg = -(int)((transform.position.x - cursorPos.x)/(Mathf.Abs(transform.position.x - cursorPos.x)));
		transform.position = new Vector3(cursorPos.x, cursorPos.y, 0f);
		float scaleNumber = (-GameObject.Find("Camera").transform.position.z / 100);
		
		transform.localScale = new Vector2(scaleNumber, scaleNumber);
		
		if(StaticThings.GameIsPaused){
			//print(speed);
			//print(speed);
			//print(posOrNeg);
					speed /= scaleNumber;
			
			float rotZ = speed * sensitivity * posOrNeg;
			float smoothRotation = Mathf.MoveTowardsAngle(rotZ2, rotZ, 0.01f);
				//print(smoothRotation);
			if(smoothRotation > 45)
			smoothRotation = 45;
			if(smoothRotation < -45)
			smoothRotation = -45;

			transform.rotation = Quaternion.Euler(0, 0, smoothRotation);
			rotZ2 = speed * sensitivity * posOrNeg;
		}
		
	}
	void FixedUpdate() {
		//creating an infinite plane
		Plane xy = new Plane(Vector3.back, Vector3.zero);
		//making the cursor ray
		Ray cursor = Camera.main.ScreenPointToRay (Input.mousePosition);
		//find distance from start of ray to point of intersection with plane
		float distance;

		xy.Raycast (cursor, out distance);


		float scaleNumber = -GameObject.Find("Camera").transform.position.z / 100;
		
		Vector2 cursorPos = cursor.GetPoint(distance);
		float speed = Mathf.Abs(transform.position.x - cursorPos.x);
		//print(speed);
		speed /= scaleNumber;
		int posOrNeg = -(int)((transform.position.x - cursorPos.x)/(Mathf.Abs(transform.position.x - cursorPos.x)));
		float rotZ = speed * sensitivity * posOrNeg;
		float smoothRotation = Mathf.MoveTowardsAngle(rotZ2, rotZ, 0.01f);
		if(smoothRotation > 45)
		smoothRotation = 45;
		if(smoothRotation < -45)
		smoothRotation = -45;
		
		transform.rotation = Quaternion.Euler(0, 0, smoothRotation);
		//print(speed);
		//print(posOrNeg);
		rotZ2 = speed * sensitivity * posOrNeg;


	}
}

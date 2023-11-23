using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	public float z;
	private Transform target;
	public float smoothSpeed = 0.125f;
	Vector3 offset;
	private Rigidbody2D rb;
	public float smoothZ = -0.2f;
	private float maxOffsetZ = -92f;
	public float minOffsetZ = -10f;
	public float changeSpeed = 1;
	private PlayerController PC;
	private int num;

	void Start(){
		if (StaticThings.offsetZ == 0) {
			StaticThings.offsetZ = minOffsetZ;
		}

		PC = (PlayerController)FindObjectOfType(typeof(PlayerController));
		rb = PC.gameObject.GetComponent<Rigidbody2D>();
		target = PC.gameObject.transform;
		maxOffsetZ = -92f;
		transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
	}
	void Update(){
		if(StaticThings.justSpawned)
			transform.position = PC.transform.position + offset;
	}
	void FixedUpdate() {
		
		

		//zooming in and out
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && StaticThings.offsetZ > maxOffsetZ) {
			StaticThings.offsetZ -= changeSpeed;
		} else if( Input.GetAxis("Mouse ScrollWheel") > 0 && StaticThings.offsetZ < minOffsetZ){
			StaticThings.offsetZ += changeSpeed;
		} 



		z = transform.position.z;
		if (PC.onGround) {
			num = 0;
		} else {
			num = 1;
		}
		//follow z

			if (rb.velocity.magnitude < 1) {
				offset = new Vector3 (0f, 0f, StaticThings.offsetZ); 
			} else {
				offset = new Vector3 (0f, 0f, rb.velocity.magnitude * smoothZ * num + StaticThings.offsetZ);
			}

		//follow xy
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
	
}

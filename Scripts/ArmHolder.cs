using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArmHolder : MonoBehaviour {
	public GameObject frontArm;
	public GameObject backArm;
	private int armNum;
	//private List<Transform> armSpotsBack = new List<Transform> ();
	//private List<Transform> armSpotsFront = new List<Transform> ();
	bool shootFrontArm = true;
	private Transform armSpotBack;
	private Transform armSpotFront;
	public List<Arm> armsBack = new List<Arm>();
	public List<Arm> armsFront = new List<Arm>();
	public int frontMinusBack;
	public float armCount = 0;
	 TMP_Text counter;


	public HingeJoint2D joint;
	//public Rigidbody2D rb;
	public Vector3 difference;
	public Vector3 target;
	public float rotzed;
	private Flip ManlyMan;
	void OnEnable() {
		ManlyMan = transform.parent.GetComponent<Flip>();

		counter = GameObject.Find("UI/Canvas/Arm Count").GetComponent<TMP_Text>();
		
		if (SceneManager.GetActiveScene().buildIndex == 6) {
			StaticThings.startArmCount = 6;
		} else if(SceneManager.GetActiveScene().buildIndex == 7){
			StaticThings.startArmCount = 3;
		} else if(SceneManager.GetActiveScene().buildIndex == 8){
			StaticThings.startArmCount = 3;
		}else if(SceneManager.GetActiveScene().buildIndex == 9){
			StaticThings.startArmCount = 3;
		}
		else if(SceneManager.GetActiveScene().buildIndex == 10){
			StaticThings.startArmCount = 8;
		}else if(SceneManager.GetActiveScene().buildIndex == 11){
			StaticThings.startArmCount = 18;
		}else if(SceneManager.GetActiveScene().buildIndex == 13){
			StaticThings.startArmCount = 16;
		}else if(SceneManager.GetActiveScene().buildIndex == 14){
			StaticThings.startArmCount = 14;
		}else if(SceneManager.GetActiveScene().buildIndex == 15){
			StaticThings.startArmCount = 3;
		}else if(SceneManager.GetActiveScene().buildIndex == 16){
			StaticThings.startArmCount = 18;
		}else if(SceneManager.GetActiveScene().buildIndex == 17){
			StaticThings.startArmCount = 14;
		}else if(SceneManager.GetActiveScene().buildIndex == 18){
			StaticThings.startArmCount = 16;
		}else if(SceneManager.GetActiveScene().buildIndex == 20){
			StaticThings.startArmCount = 50;
		}else {
			StaticThings.startArmCount = 2;
		}

		if(PlayerPrefs.GetInt("infinite") == 0){
			armCount = StaticThings.startArmCount;
		} else{
			armCount = Mathf.Infinity;
		}
		
		if(armCount % 2 != 0){
			shootFrontArm = false;
		}

		for (int i = 0; i < gameObject.transform.childCount; i++) {
			Transform currentChild = gameObject.transform.GetChild (i);
			if(currentChild.CompareTag("Arm Spot Back")){
				armSpotBack = currentChild;
			}
		}
		for (int i = 0; i < gameObject.transform.childCount; i++) {
			Transform currentChild = gameObject.transform.GetChild (i);
			if(currentChild.CompareTag("Arm Spot Front")){
				armSpotFront = currentChild;
			}
		}
		MakeArm(backArm, armSpotBack);
		MakeArm(frontArm, armSpotFront);
		//armSpotBack.GetComponent<CreateArm>().MakeArm(backArm, new Vector3(0.35f,1.77f, 0f));
		//armSpotFront.GetComponent<CreateArm>().MakeArm(frontArm, new Vector3(-0.35f,1.77f, 0f));
		
		/*for (int i = 0; i < gameObject.transform.childCount; i++) {
			Transform currentChild = gameObject.transform.GetChild (i);
			if(currentChild.CompareTag("Arm")){
				armCount++;
			}
		}*/
		UpdateCounter ();
		//print(armSpotBack.localPosition);
	}
	public void MakeArm(GameObject arm, Transform armSpot){
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
		GameObject armG = Instantiate(arm);
		armG.transform.position = armSpot.position;
		armG.transform.SetParent(armSpot);

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

		armG.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotzed));
		//Instantiate (arm, armSpot.localPosition, Quaternion.identity, armSpot);
	}
	/*private void RefreshArmLists(){
		foreach (Transform frontSpot in armSpotsFront) {
			for (int i = 0; i <= frontSpot.childCount - 1; i++) {
				if(!armsFront.Contains(frontSpot.GetChild(i).GetComponent<Arm>()))
				armsFront.Add(frontSpot.GetChild(i).GetComponent<Arm>());
			}
		}
		foreach (Transform backSpot in armSpotsBack) {
			for (int i = 0; i <= backSpot.childCount - 1; i++) {
				if(!armsBack.Contains(backSpot.GetChild(i).GetComponent<Arm>()))
				armsBack.Add(backSpot.GetChild(i).GetComponent<Arm>());
			}
		}
	}*/

	public void Shoot(float speed){
		//RefreshArmLists ();
		armCount--;
		UpdateCounter ();

	/*	if (HasMoreFront () && true ){
			armsFront [armsFront.Count-1].Launch (speed);
			armsFront.RemoveAt(armsFront.Count - 1);
			armsFront.RemoveAt (armsFront.Count - 1);
			//shoot front
		} else if(true){
			armsBack [armsBack.Count-1].Launch (speed);
			armsBack.RemoveAt(armsBack.Count - 1);
			armsBack.RemoveAt (armsBack.Count - 1);
			//shoot back
		}*/
		
		//print(shootFrontArm);	
		if(shootFrontArm){
			if(armCount>=2){
				//armSpotFront.GetComponent<CreateArm>().MakeArm(frontArm, new Vector3(-0.35f,1.77f, 0f));
				//transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotz ()));
						
				MakeArm(frontArm, armSpotFront);
			}
			armSpotFront.GetChild(0).GetComponent<Arm>().Launch(speed);	
		} else {
			if(armCount>=2)
				//armSpotBack.GetComponent<CreateArm>().MakeArm(backArm, new Vector3(0.35f,1.77f, 0f));
				MakeArm(backArm, armSpotBack);
			armSpotBack.GetChild(0).GetComponent<Arm>().Launch(speed);
		}
		shootFrontArm = !shootFrontArm;
		ManlyMan.UpdateArmList();
	}
	public bool HasArms(){
		if(armCount > 0){
			return true;
		} else {
			return false;
		}
	}
	/*public bool HasMoreFront(){
		if (!HasArms ()) {
			return false;
		}
		frontMinusBack = armsFront.Count - armsBack.Count;

		if (frontMinusBack > 0) {
			return true;
		} else {
			return false;
		}
	}*/

	//Instantiate (frontArm, armSpotsFront[0].transform);
	//Instantiate (backArm, armSpotsBack[0].transform);
	//public void AddArm(int arms){
		/*for (int i = 1; i <= arms; i++) {
			if (HasMoreFront () && armsBack.Count < armSpotsBack.Count) {
				//add back
		*/
		
				//armSpotBack.GetComponent<CreateArm>().MakeArm(backArm);
			

				//arm.transform.parent = armSpotsBack [armsBack.Count];

			//} else if (armsFront.Count < armSpotsFront.Count) {
				//add front
				//armSpotFront.GetComponent<CreateArm>().MakeArm(frontArm);
				//arm.transform.parent = armSpotsFront [armsFront.Count];
			//}
			//armCount++;
			//UpdateCounter ();
			//RefreshArmLists ();
		//}

//}

	void UpdateCounter () {
		if(PlayerPrefs.GetInt("UI") == 1){
			counter.SetText ("");	
		} else {
			counter.SetText ("Arm Count: " + armCount);
		}
	}
	void Update(){
		if(StaticThings.justSpawned)
			armCount = StaticThings.startArmCount;
	}
}

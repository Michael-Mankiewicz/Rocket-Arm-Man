using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 5;
	public float waitTime = 0.3f;

	public Transform pathHolder;
	private Rigidbody2D rb;

	private bool starting = true;
	public bool waitOnStart = true;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints [i] = pathHolder.GetChild (i).position;
		}

		StartCoroutine (FollowPath (waypoints));
	}

	IEnumerator FollowPath(Vector3[] waypoints) {
		transform.position = waypoints [0];

		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints [targetWaypointIndex];

		while (true) {
			if (waitOnStart && starting) {
				starting = false;
				yield return new WaitForSeconds (waitTime);
			}
			//transform.position = Vector3.MoveTowards (transform.position, targetWaypoint, speed * Time.deltaTime);
			rb.MovePosition(Vector3.MoveTowards(rb.position, targetWaypoint, speed * Time.deltaTime));
			if (Mathf.Abs(Vector3.Distance(transform.position, targetWaypoint)) < 0.1f ) {
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				targetWaypoint = waypoints [targetWaypointIndex];
				yield return new WaitForSeconds (waitTime);
			}
			yield return null;
		}
	}

	void OnDrawGizmos(){
		Vector3 startPosition = pathHolder.GetChild (0).position;
		Vector3 previousPosition = startPosition;

		foreach (Transform waypoint in pathHolder) {
			Gizmos.DrawSphere (waypoint.position, 1f);
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		Gizmos.DrawLine (previousPosition, startPosition);
	}


}

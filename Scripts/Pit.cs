using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pit : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.layer == 11){
			StaticThings.firstTimePlayingLevel = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			/*coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			StaticThings.justSpawned = true;
			coll.gameObject.transform.position = coll.gameObject.GetComponent<PlayerController>().spawnPoint.position;*/
			PlayerPrefs.SetInt ("deaths", PlayerPrefs.GetInt ("deaths") + 1);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : MonoBehaviour {

	public GameObject PlayerShooting;
	public GameObject EnvironmentPiece;
	bool firstTrigger = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && firstTrigger) {
			//Debug.Log ("triggered");
			firstTrigger = false;
			gameObject.GetComponent<SoundMaker> ().MakeSound ();
			//Debug.Log ("try to equip");
			gameObject.transform.position = new Vector3 (2000, 2000, 0);

			PlayerShooting.GetComponent<ShootingBehaviour>().Equip(EnvironmentPiece);
			gameObject.GetComponent<AudioSource>().Play ();
			//Debug.Log ("equip");

		}
	}
}

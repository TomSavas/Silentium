using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTriggered : MonoBehaviour {

	public GameObject Civilian;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void OnTriggerEnter2D(Collider2D other) {
		if (!Civilian.GetComponent<CivilianAI> ().triggered) {
			Civilian.GetComponent<CivilianAI> ().speed *= 2;
			Civilian.GetComponent<CivilianAI> ().triggered = true;
			Civilian.GetComponent<CivilianAI> ().currentWaypoint--;

		}
	}


}

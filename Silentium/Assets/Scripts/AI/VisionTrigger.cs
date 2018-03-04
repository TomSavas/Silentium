using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTrigger : MonoBehaviour {
	public CivilianAI Civilian;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Civilian.TriggerPanic ();
		}
        if (other.gameObject.CompareTag("Body"))
        {
			;
        }
		if(other.gameObject.CompareTag("NPC")) {
			//gameObject.GetComponentInParent<CivilianAI> ().triggered = true;
		}
    }
}
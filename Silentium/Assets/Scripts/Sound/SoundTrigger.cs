using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {
	public CivilianAI Civilian;

	private void OnParticleCollision(GameObject particle) {
		if (particle.CompareTag ("Sound")) {
			Civilian.TriggerPanic ();
		}
	}
}
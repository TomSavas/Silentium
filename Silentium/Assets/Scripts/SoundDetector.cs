using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SoundDetector : MonoBehaviour {
	private Action _onSoundDetected = null;

	public void SetOnSoundDetected(Action onSoundDetected) {
		_onSoundDetected = onSoundDetected;
	}		

	private void OnParticleCollision(GameObject particle) {
		if (particle.CompareTag(GlobalConsts.SOUND_TAG)) {
			if(_onSoundDetected != null) 
				_onSoundDetected ();
		}
	}
}
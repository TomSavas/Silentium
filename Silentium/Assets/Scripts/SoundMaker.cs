using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaker : MonoBehaviour {
	public ParticleSystem SoundParticlePrefab;

	private ParticleSystem _particleSystem;

	protected void Start() {
		_particleSystem = Instantiate (SoundParticlePrefab, this.GetComponent<Transform> ());
	}

	public void MakeSound() {
		_particleSystem.Play ();
	}
}
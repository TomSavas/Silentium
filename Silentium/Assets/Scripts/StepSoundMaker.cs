using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundMaker : MonoBehaviour {
	public float SteppingFrequency = 1f;

	private float DEFAULT_STEPPING_FREQUENCY;

	private ParticleSystem _stepParticles;
	private Transform _transform;
	private Vector2 _previousPosition;

	private void Start() {
		DEFAULT_STEPPING_FREQUENCY = SteppingFrequency;
		_stepParticles = GetComponentInChildren<ParticleSystem>();
		_transform = GetComponent<Transform> ();
	
		SavePosition();
	}

	private void Update() {
		if (ShouldMakeAStep()) {
			MakeSteppingSound ();
			SavePosition ();
		}
	}

	private void SavePosition() {
		_previousPosition = _transform.position;
	}

	private bool ShouldMakeAStep() {
		return Vector2.Distance (_transform.position, _previousPosition) >= SteppingFrequency;
	}

	private void MakeSteppingSound() {
		_stepParticles.Play ();
	}

	public void ResetSteppingFrequency() {
		SteppingFrequency = DEFAULT_STEPPING_FREQUENCY;
	}
}
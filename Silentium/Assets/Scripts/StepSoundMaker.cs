using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundMaker : SoundMaker {
	public float SteppingFrequency = 1f;

	private float DEFAULT_STEPPING_FREQUENCY;

	private Transform _transform;
	private Vector2 _previousPosition;

	private void Start() {
		base.Start ();

		DEFAULT_STEPPING_FREQUENCY = SteppingFrequency;
		_transform = GetComponent<Transform> ();
	
		SavePosition();
	}

	private void Update() {
		if (ShouldMakeAStep()) {
			MakeSound();
			SavePosition ();
		}
	}

	private void SavePosition() {
		_previousPosition = _transform.position;
	}

	private bool ShouldMakeAStep() {
		return Vector2.Distance (_transform.position, _previousPosition) >= SteppingFrequency;
	}

	public void ResetSteppingFrequency() {
		SteppingFrequency = DEFAULT_STEPPING_FREQUENCY;
	}
}
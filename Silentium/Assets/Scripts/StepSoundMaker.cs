using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundMaker : SoundMaker {
	public float SteppingFrequency = 1f;

	private float DEFAULT_STEPPING_FREQUENCY;
	private float DEFAULT_PARTICLE_LIFETIME;

	private Transform _transform;
	private Vector2 _previousPosition;

	private void Start() {
		base.Start ();

		DEFAULT_STEPPING_FREQUENCY = SteppingFrequency;
		DEFAULT_STEPPING_FREQUENCY = _particleSystem.main.startLifetime.constant;
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

	public void ResetParticleLifetime() {
		var mainParticles = _particleSystem.main;
		mainParticles.startLifetime = new ParticleSystem.MinMaxCurve(DEFAULT_PARTICLE_LIFETIME);
	}

	public void EnableSneakingSteps() {
		var mainParticles = _particleSystem.main;
		mainParticles.startLifetime = new ParticleSystem.MinMaxCurve(_particleSystem.main.startLifetime.constant / 2);
		SteppingFrequency = SteppingFrequency * 2;
	}

	public void EnableRunningSteps() {
		var mainParticles = _particleSystem.main;
		mainParticles.startLifetime = new ParticleSystem.MinMaxCurve(_particleSystem.main.startLifetime.constant * 2);
		SteppingFrequency = SteppingFrequency / 2;
	}

	public void EnableWalkingSteps() {
		ResetParticleLifetime ();
		ResetSteppingFrequency ();
	}
}
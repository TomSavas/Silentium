using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStats : MonoBehaviour {
	public const float DEFAULT_WALKING_SPEED = 0.05f;
	public const float DEFAULT_RUNNING_SPEED = DEFAULT_WALKING_SPEED * 1.5f;
	public const float DEFAULT_SNEAKING_SPEED = DEFAULT_WALKING_SPEED * 0.33f;

	public const int DEFAULT_HEALTH = 1;

	public float speed = DEFAULT_WALKING_SPEED;
	public int health = DEFAULT_HEALTH;
	public int damage = DEFAULT_HEALTH;

	public void SetWalkingSpeed() {
		SetSpeed (DEFAULT_WALKING_SPEED);
	}

	public void SetRunningSpeed() {
		SetSpeed (DEFAULT_RUNNING_SPEED);
	}

	public void SetSneakingSpeed() {
		SetSpeed (DEFAULT_SNEAKING_SPEED);
	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}
}

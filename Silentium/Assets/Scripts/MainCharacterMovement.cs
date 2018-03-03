using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour {

	// Use this for initialization
	float speed = 0.2f;
	float walkingSpeed = 0.05f;
	float runningSpeedMultiplyer = 1.5f;
	float sneakingSpeedMultiplyer = 0.33f;
	float depletionRate = 10f; 					
	float stamina = 1f;
	float staminaDepletionSpeed = 0.0010f;
	float staminaRegenerationSpeed = 0.0005f;
	float timeSinceStaminaUsed = 0;

	bool running = false;
	bool sneaking = false;

	public GameObject staminaBar;
	public GameObject staminaBarFilling;

	private StepSoundMaker _stepSoundMaker;

	void Start () {
		_stepSoundMaker = GetComponent<StepSoundMaker> (); 
		speed = walkingSpeed;
		staminaBar.SetActive(false);
	}
	
 	void Walk() {
		speed = walkingSpeed;
		running = false;
		sneaking = false;
		timeSinceStaminaUsed = Time.time;
		_stepSoundMaker.EnableWalkingSteps ();

	}

	void Run() {
		staminaBar.SetActive(true);
		staminaBarFilling.transform.localScale = new Vector3 (stamina, 1, 0);
		speed = speed * runningSpeedMultiplyer;
		running = true;
		_stepSoundMaker.EnableRunningSteps ();
	}

	void Sneak() {
		speed = speed * sneakingSpeedMultiplyer;
		sneaking = true;
		_stepSoundMaker.EnableSneakingSteps ();
	}
		
	void FixedUpdate () {
		
		float vertical = Input.GetAxis ("Vertical") * speed;
		float horizontal = Input.GetAxis ("Horizontal") * speed;
		transform.position += new Vector3 (horizontal, vertical, 0);
		if(Input.GetKeyDown(KeyCode.LeftShift) && !sneaking) {
			Run();
		}
		if(Input.GetKeyUp(KeyCode.LeftShift) && running) {
			Walk();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl) && !running) {
			Sneak ();
		}
		if (Input.GetKeyUp (KeyCode.LeftControl) && sneaking) {
			Walk ();
		}
		
		if (running && (vertical != 0 || horizontal != 0)) {
				staminaBarFilling.transform.localScale -= new Vector3 (staminaDepletionSpeed, 0f, 0);
				stamina -= staminaDepletionSpeed;
				timeSinceStaminaUsed = Time.time;
				if (stamina <= 0f) {
					Walk ();
				}
		} else {
			if (stamina < 1f && (Time.time - timeSinceStaminaUsed > 3)) {
				stamina += staminaRegenerationSpeed;
				staminaBarFilling.transform.localScale += new Vector3 (staminaRegenerationSpeed, 0, 0);
			}
			if (Time.time - timeSinceStaminaUsed > 5 && staminaBar.activeInHierarchy) {
				staminaBar.SetActive(false);
			}
		}

	}

}

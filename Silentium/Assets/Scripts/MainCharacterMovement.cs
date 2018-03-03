using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
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
	private PersonStats _personStats;
	private Animator _animator;

	void Start () {
		_stepSoundMaker = GetComponent<StepSoundMaker> ();
		_personStats = GetComponent<PersonStats> ();
		_personStats.SetWalkingSpeed ();
		_animator = GetComponent<Animator> ();
		staminaBar.SetActive(false);
	}
	
 	void Walk() {
		_personStats.SetWalkingSpeed ();
		running = false;
		sneaking = false;
		timeSinceStaminaUsed = Time.time;
		_stepSoundMaker.EnableWalkingSteps ();

	}

	void Run() {
		staminaBar.SetActive(true);
		staminaBarFilling.transform.localScale = new Vector3 (stamina, 1, 0);
		_personStats.SetRunningSpeed ();
		running = true;
		_stepSoundMaker.EnableRunningSteps ();
	}

	void Sneak() {
		_personStats.SetSneakingSpeed ();
		sneaking = true;
		_stepSoundMaker.EnableSneakingSteps ();
	}
		
	void Update() {
		FaceTheDirectionOfWalking ();
	}

	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical") * _personStats.speed;
		float horizontal = Input.GetAxis ("Horizontal") * _personStats.speed;
		transform.position += new Vector3 (horizontal, vertical, 0);

		if (vertical != 0 || horizontal != 0) {
			_animator.SetBool ("Walk", true);
		} else {
			_animator.SetBool ("Walk", false);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (!sneaking && stamina > 0)
				Run ();
		} else if (Input.GetKeyUp(KeyCode.LeftShift)) {
			if (running)
				Walk ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!running)
				Sneak ();
		} else if (Input.GetKeyUp (KeyCode.Space)){
			if (sneaking)
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

	private void FaceTheDirectionOfWalking() {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			var verticalAngle = Input.GetKey(KeyCode.W) ? 0 : Input.GetKey(KeyCode.S) ? -180 : 0;
			var horizontalAngle = Input.GetKey(KeyCode.D) ? -90 : Input.GetKey(KeyCode.A) ? 90 : 0;
			var twoDirectionsPressed = (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) && (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S));
			transform.rotation = Quaternion.Euler (0, 0, (verticalAngle + horizontalAngle) / (twoDirectionsPressed ? 2 : 1));
		}
	}
}

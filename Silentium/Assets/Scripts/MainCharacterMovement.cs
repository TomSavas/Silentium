using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour {

	// Use this for initialization
	float speed = 0.2f;
	float walkingSpeed = 0.05f;
	float runningSpeed = 0.02f;

	void Start () {
		speed = walkingSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Walk() {
		speed = walkingSpeed;
	}

	public void Run() {
		speed = runningSpeed;
	}

	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical") * speed;
		float horizontal = Input.GetAxis ("Horizontal") * speed;
		transform.position += new Vector3 (horizontal, vertical, 0);
	}

}

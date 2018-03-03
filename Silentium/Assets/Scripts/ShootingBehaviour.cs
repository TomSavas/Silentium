using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour {

	public AnimationCurve curve;
	public GameObject Player;
	public float aimingSpeed = 0.5f;
	public GameObject equipedObject;
	bool equiped = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void FixedUpdate() {
		if (Input.GetKey (KeyCode.F)) {
			if(Mathf.Pow(gameObject.transform.localPosition.x, 2) + Mathf.Pow(gameObject.transform.localPosition.y, 2) < 10) 
				//gameObject.transform.localPosition += Player.GetComponent<MainCharacterMovement> ().facingDirection*aimingSpeed;
				gameObject.transform.localPosition += new Vector3(0, 1, 0)*aimingSpeed*2;
		}
		if (Input.GetKeyUp (KeyCode.F)) {
			//Debug.Log ("stop aiming");
			if (equiped) {
				Player.GetComponent<Throw> ().ThrowItem (equipedObject, gameObject.transform.position);
				equiped = false;
			}
			gameObject.transform.localPosition = new Vector3 (0, 0, 0);
			equiped = false;
			equipedObject.transform.position = Player.transform.position;
		}
	}

	public void Equip(GameObject throwable) {
		//Debug.Log ("Equiped succesfully");
		equiped = true;
		equipedObject = throwable;
	}
}

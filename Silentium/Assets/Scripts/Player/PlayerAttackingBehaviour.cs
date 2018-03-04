using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {
	public Animator slash;

	private void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			slash.speed = 2.5f;
			slash.SetBool ("Slash", true);
		} else {
			slash.SetBool ("Slash", false);
		}
	}
}
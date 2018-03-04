using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {
	public Animator slash;

	private void Update() {
		if (slash.IsInTransition (0)) {
			Destroy (slash.gameObject.GetComponent<PolygonCollider2D> ());
			var polyCollider = slash.gameObject.AddComponent<PolygonCollider2D> ();
			polyCollider.isTrigger = true;
		}
	}

	private void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			slash.speed = 2.5f;
			slash.SetBool ("Slash", true);
		} else {
			slash.SetBool ("Slash", false);
			Destroy (slash.gameObject.GetComponent<PolygonCollider2D> ());
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingBehaviour : MonoBehaviour {
	public GameObject knife;
	public float slashingTime;

	private void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			StartCoroutine(Attack ());
		}
	}

	private IEnumerator Attack() {
		knife.SetActive (true);
		knife.GetComponent<Transform> ().rotation = Quaternion.identity;

		var startingTime = Time.time;
		while (Time.time < (startingTime + slashingTime)) {
			float percentage = (Time.time - startingTime) / slashingTime;
			var angle = Mathf.Lerp (45, -45, percentage);
			knife.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 0, angle);

			yield return null;
		}
		knife.SetActive (false);
	}
}
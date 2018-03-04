using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour {
	private PersonStats _personStats;

	private void Start () {
		_personStats = GetComponent<PersonStats> ();
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log (collider.gameObject.tag);
		if (collider.gameObject.CompareTag ("Weapon")) {
			_personStats.health -= collider.gameObject.GetComponentInParent<PersonStats> ().damage;
		}
	}
}

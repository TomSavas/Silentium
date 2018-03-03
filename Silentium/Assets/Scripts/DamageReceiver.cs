using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour {
	private PersonStats _personStats;

	private void Start () {
		_personStats = GetComponent<PersonStats> ();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log (collision.gameObject.tag);
		if (collision.gameObject.CompareTag ("Weapon")) {
			_personStats.health -= collision.gameObject.GetComponentInParent<PersonStats> ().damage;
		}
	}

	private void Update () {
		if (_personStats.health <= 0) {
			Destroy (this.gameObject);
		}
	}
}

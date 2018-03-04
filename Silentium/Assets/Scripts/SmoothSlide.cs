using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSlide : MonoBehaviour {

	void Start () {
		StartCoroutine (Transit () );
	}

	public GameObject centre;

	void Go() {
		transform.position = Vector3.Lerp (transform.position, centre.transform.position, 0.1f);
	}

	private IEnumerator Transit(){
		int n = 0;
		while (Vector3.Distance (transform.position, centre.transform.position) >= 0.01) {
			Go ();
			yield return null;
		}
	}
}

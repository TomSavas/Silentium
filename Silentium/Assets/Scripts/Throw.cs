using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
	float flyingSpeed = 5f;
	float flyingStart;
	public AnimationCurve curve;
	bool throwing = false;
	GameObject throwItem;
	Vector3 endPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (throwing) {
			//Debug.Log ("throwing");
			throwItem.transform.position = Vector3.MoveTowards(throwItem.transform.position, endPosition, flyingSpeed * Time.deltaTime * curve.Evaluate((Time.time - flyingStart)/2.5f));
			if (Vector3.Distance (throwItem.transform.position, endPosition) < 0.02) {
				throwing = false;
				throwItem.GetComponent<SoundMaker> ().MakeSound ();
				throwItem.transform.position = new Vector3 (2000, 2000, 0);
			}
		}
	}

	public void ThrowItem(GameObject Item, Vector3 endPos) {
		//Debug.Log ("ThrowItem");
		throwing = true;
		throwItem = Item;
		flyingStart = Time.time;
		endPosition = endPos;
	}
}

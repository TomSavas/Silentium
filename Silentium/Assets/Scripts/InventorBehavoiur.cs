using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorBehavoiur : MonoBehaviour {

	Sprite empty;

	public GameObject ShootingTarget;
	// Use this for initialization
	void Start () {
		empty = gameObject.GetComponentInChildren<Image> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if (ShootingTarget.GetComponent<ShootingBehaviour> ().equiped) {
			//Debug.Log ("equipted");
			gameObject.GetComponentInChildren<Image> ().sprite = ShootingTarget.GetComponent<ShootingBehaviour> ().equipedObject.GetComponent<SpriteRenderer> ().sprite;
			//gameObject.GetComponentInChildren<Image>().
			//gameObject.GetComponentInChildren<> ().sprite = Player.GetComponent<ShootingBehaviour> ().equipedObject.GetComponent<SpriteRenderer> ().sprite;
		} else {
			//gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
			//Debug.Log("not equipted");
			gameObject.transform.GetComponentInChildren<Image> ().sprite = empty;
		}
	}
}

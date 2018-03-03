using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public GameObject chooseLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSelection() {
		//Debug.Log("SelectionStarted");
		chooseLevel.SetActive(true);
		gameObject.SetActive (false);
	}
}

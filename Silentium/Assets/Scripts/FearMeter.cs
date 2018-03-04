using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearMeter : MonoBehaviour {
     void Start() { 
	}

	public void Display(float percentage) {
        print(percentage);
		var scale = GetComponent<Transform> ().localScale;
		GetComponent<Transform> ().localScale = new Vector3 (percentage, scale.y, scale.z);
	}
}
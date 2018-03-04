using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedRotationFromParent : MonoBehaviour {
	private Quaternion _rotation;

	private Vector3 _positionDiff;

	void Start () {
		_rotation = transform.rotation;
		_positionDiff = transform.parent.transform.position - transform.position;
	}
	
	void Update () {
		transform.rotation = Quaternion.Euler(0, 0, 0);
		transform.position = transform.parent.position - _positionDiff;
	}
}

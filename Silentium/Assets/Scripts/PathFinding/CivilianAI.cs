using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CivilianAI : MonoBehaviour {

    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    public float speed = 3f;
	public bool triggered = false;
	public int panicCooldown;

	public GameObject Vision;

	private void FixedUpdate () {
		if (!triggered) {
			if (Vector3.Distance (transform.position, waypoints [currentWaypoint].position) < 0.1f)
				currentWaypoint++;
			if (currentWaypoint >= waypoints.Capacity)
				currentWaypoint = 0;
		} else {
			if (Vector3.Distance (transform.position, waypoints [currentWaypoint].position) < 0.1f)
				currentWaypoint--;
			if (currentWaypoint < 0)
				currentWaypoint = waypoints.Capacity - 1;
		}
        var dir = waypoints[currentWaypoint].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Vision.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed*Time.deltaTime);
		//transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }

	public void TriggerPanic() {
		if (!triggered) {
			speed *= 2;
			triggered = true;
			currentWaypoint--;
			if (currentWaypoint < 0) {
				currentWaypoint = waypoints.Capacity - 1;
			}

			StartCoroutine(Reset());
		}
	}

	private IEnumerator Reset() {
		yield return new WaitForSeconds (panicCooldown);
		ResetPanic ();
	}

	public void ResetPanic() {
		if (triggered) {
			speed /= 2;
			triggered = false;
		}
	}
}

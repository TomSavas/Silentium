using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianAI : MonoBehaviour {

    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    public float speed = 3f;
	public bool triggered = false;
    // Use this for initialization
    void Start () {
		
	}

	public GameObject Vision;
	// Update is called once per frame
	void FixedUpdate () {
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

        //transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

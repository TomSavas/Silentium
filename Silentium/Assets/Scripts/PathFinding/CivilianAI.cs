using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianAI : MonoBehaviour {

    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    float speed = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f) currentWaypoint++;
        if (currentWaypoint >= waypoints.Capacity) currentWaypoint = 0;

        var dir = waypoints[currentWaypoint].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

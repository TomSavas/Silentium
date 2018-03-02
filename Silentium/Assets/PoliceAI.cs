using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAI : MonoBehaviour {

    #region variables
    public List<Transform> waypoints;
    int currentWaypoint=0;
    float speed = 1f;
    int mode = 0;
    #endregion

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        #region Waypoints (mode 0)
        if (mode == 0)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.01f) currentWaypoint++;
            if (currentWaypoint >= waypoints.Capacity) currentWaypoint = 0;

            var dir = waypoints[currentWaypoint].position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        #endregion
        #region Alert (mode 1)
        #endregion
    }
}

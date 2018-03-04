﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoliceAI : MonoBehaviour
{
	public GameObject District;

    #region variables
	List<Transform> allWaypoints;  
	List<Transform> waypoints = new List<Transform>();
    public int currentWaypoint = 0;
	int waypointsCapacity = 0;
    float speed = 3f;
    public int mode = 0;
    float cooldown = 0;
    public GameObject player;
    public bool seePlayer = false;
    public GameObject Vision;
    float followCooldown;
    float fearCooldown=0;
    public FearManager fearManager;
    #endregion

    void Start()
    {
        gameObject.GetComponent<Unit>().PathEnd += OnPathEnd;
		allWaypoints = District.GetComponentsInChildren<Transform> ().ToList();

		int randomCounter = (int)((Time.time) % 20f) + 12;
		Debug.Log (randomCounter);
		Vector3 currentPosition = this.transform.position;

		for (int i = 0; i < 30; ++i) {
			//Random rnd = new System.Random();
			//Debug.Log (i);
			int randomIndex = (int)UnityEngine.Random.Range(0, allWaypoints.Capacity - 2);
			//Debug.Log (allWaypoints.Capacity);
			//Debug.Log (randomIndex);
			bool con = true;
			for (int j = randomIndex + 1; j < allWaypoints.Capacity && con; j++) {
				//Debug.Log (i + " " + j);
				//Debug.Log ("current position " + currentPosition.x + " " + currentPosition.y);
				//Debug.Log ("this waypoint position" + allWaypoints [j].transform.position.x + " " + allWaypoints [j].transform.position.y);
				if (Mathf.Abs (currentPosition.x - allWaypoints [j].transform.position.x) < 1 || Mathf.Abs (currentPosition.y - allWaypoints [j].transform.position.y) < 1) {
					if (Vector3.Distance (currentPosition, allWaypoints [j].transform.position) < 10) {
						//Debug.Log (i + " " + j);
						//Debug.Log ("this waypoint position" + allWaypoints [j].transform.position.x + " " + allWaypoints [j].transform.position.y);
						//Debug.Log ("current position " + currentPosition.x + " " + currentPosition.y);
						//Debug.Log ("found");
						waypoints.Add (allWaypoints[j]);
						waypointsCapacity++;
						currentPosition = allWaypoints [j].transform.position;
						con = false;
					}
				}

			}
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!seePlayer) cooldown += Time.deltaTime;
        fearCooldown -= Time.deltaTime;

        followCooldown += Time.deltaTime;
        #region Waypoints (mode 0)
        if (mode == 0)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f) currentWaypoint++;
            if (currentWaypoint >= waypoints.Capacity) currentWaypoint = 0;

            var dir = waypoints[currentWaypoint].position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }

        #endregion

        if (mode == 1 && cooldown > 10)
        {
            mode = 2;
            gameObject.GetComponent<Unit>().target = waypoints[currentWaypoint];
            gameObject.GetComponent<Unit>().PathFindToTarget();
        }
    }
    public void OnPathEnd()
    {
        //Destroy(gameObject.GetComponent<Unit>().target.gameObject);
        if (mode == 1)
        {
            seePlayer = false;
        }
        else if (mode == 2)
        {
            mode = 0;
        }
    }
    public void Chase()
    {
        if (followCooldown > 0.3f)
        {
            cooldown = 0;
            GameObject temp = new GameObject();
            Destroy(temp, 10);
            temp.transform.position = player.transform.position;
            gameObject.GetComponent<Unit>().target = temp.transform;
            gameObject.GetComponent<Unit>().PathFindToTarget();
            seePlayer = true;
            mode = 1;
            followCooldown = 0;
        }
        if (fearCooldown < 0)
        {
            fearManager.IncreaseForBeingNoticed();
            fearCooldown = 1;
        }
    }
}
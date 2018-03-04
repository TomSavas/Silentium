using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CivilianAI : MonoBehaviour {

	public GameObject District;

	List<Transform> allWaypoints;  
	List<Transform> waypoints = new List<Transform>();
    public int currentWaypoint = 0;
	public int waypointsCapacity = 0;
    public float speed = 3f;
	public bool triggered = false;
	public int panicCooldown;
    public bool goingBack=false;
    public GameObject Grid;
    public FearManager fearManager;

	public GameObject Vision;

    public void Start()
    {
		Debug.Log ("Start");
		gameObject.GetComponent<Unit>().PathEnd += OnPathEnd;
		allWaypoints = District.GetComponentsInChildren<Transform> ().ToList();
		Debug.Log ("WayPoints");
		//float random = (Time.time);
		//Debug.Log (random);
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

    private void FixedUpdate () {
		
		if (!triggered) {
			if (Vector3.Distance (transform.position, waypoints [currentWaypoint].position) < 0.1f)
				currentWaypoint++;
			if (currentWaypoint >= waypointsCapacity)
				currentWaypoint = 0;
		} else {
			if (Vector3.Distance (transform.position, waypoints [currentWaypoint].position) < 0.1f)
				currentWaypoint--;
			if (currentWaypoint < 0)
				currentWaypoint = waypointsCapacity - 1;
		}
        if (!triggered && !goingBack)
        {
            var dir = waypoints[currentWaypoint].position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        	
    }

	public void TriggerPanic() {
		if (!triggered) {
            fearManager.IncreaseForBeingNoticed();
            //speed *= 2;
            gameObject.GetComponent<Unit>().speed *= 2;
            triggered = true;
			currentWaypoint--;
			if (currentWaypoint < 0) {
				currentWaypoint = waypointsCapacity - 1;
			}

            gameObject.GetComponent<Unit>().target = Randomizer.FindRandomPointInArea(10, 5, transform.position, Grid.GetComponent<Grid>());
            gameObject.GetComponent<Unit>().PathFindToTarget();

            StartCoroutine(Reset());
		}
	}

	private IEnumerator Reset() {
		yield return new WaitForSeconds (panicCooldown);
		ResetPanic ();
	}

	public void ResetPanic() {
		if (triggered) {
            //speed /= 2;
            gameObject.GetComponent<Unit>().speed /= 2;
            triggered = false;
            goingBack = true;
            gameObject.GetComponent<Unit>().target = waypoints[currentWaypoint];
            gameObject.GetComponent<Unit>().PathFindToTarget();
        }
	}
    void OnPathEnd()
    {
        if (triggered)
        {
            gameObject.GetComponent<Unit>().target = Randomizer.FindRandomPointInArea(10, 5, transform.position, Grid.GetComponent<Grid>());
            gameObject.GetComponent<Unit>().PathFindToTarget();
        }
        if (goingBack == true)
        {
            goingBack = false;
        }
    }
}

			/*for (int i = 0; i < randomCounter; ++i) {
			Debug.Log (i);
			int randomIndex = (int)((Time.time + 1) * 1000) % allWaypoints.Capacity;
			Debug.Log (allWaypoints.Capacity);
			Debug.Log (randomIndex);

			for (int j = randomIndex + 1; j!=randomIndex; j++) {
				Debug.Log ("current position " + currentPosition.x + " " + currentPosition.y);
				Debug.Log ("this waypoint position" + allWaypoints[j].transform.position.x + " " + allWaypoints[j].transform.position.y);
				/*if (Mathf.Abs (currentPosition.x - allWaypoints [j].transform.position.x) < 10 || Mathf.Abs (currentPosition.y - allWaypoints [j].transform.position.y) < 10) {
					if (Vector3.Distance (currentPosition, allWaypoints [i].transform.position) < 10) {
						Debug.Log ("found");
						waypoints.Add (allWaypoints[j]);
						currentPosition = allWaypoints [j].transform.position;
						break;
					}
				}
				*/
			/*		if (j > allWaypoints.Capacity) {
			j = -1;
			}
			}

			}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAI : MonoBehaviour
{

    #region variables
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    float speed = 3f;
    public int mode = 0;
    public GameObject soundOriginGameObject;
    public Transform soundOrigin;
    #endregion

    void Start()
    {
        gameObject.GetComponent<Unit>().PathEnd += OnPathEnd;
        soundOriginGameObject = new GameObject();
        soundOrigin = soundOriginGameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        #region Mode control
        if (Input.GetMouseButtonDown(0))
        {
            soundOrigin.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            soundOrigin.position = new Vector3(soundOrigin.position.x, soundOrigin.position.y, 0);
            mode = 1;
            changeAIMode();
        }

        #endregion
        #region Waypoints (mode 0)
        if (mode == 0)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f) currentWaypoint++;
            if (currentWaypoint >= waypoints.Capacity) currentWaypoint = 0;

            var dir = waypoints[currentWaypoint].position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        #endregion
    }
    public void changeAIMode()
    {
        #region Alert (mode 1)
        if (mode == 1)
        {
            gameObject.GetComponent<Unit>().target = soundOrigin;
            gameObject.GetComponent<Unit>().PathFindToTarget();
        }
        #endregion
        #region Return to patrolling(mode 2)
        if (mode == 2)
        {
            gameObject.GetComponent<Unit>().target = waypoints[currentWaypoint];
            gameObject.GetComponent<Unit>().PathFindToTarget();
        }
        #endregion
    }
    public void OnPathEnd()
    {
        if (mode == 1)
        {
            mode = 2;
        }
        else if (mode == 2)
        {
            mode = 0;
        }
        changeAIMode();
    }
}
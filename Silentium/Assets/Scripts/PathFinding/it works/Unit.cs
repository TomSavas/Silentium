using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public Transform target;
	float speed = 3;
	Vector3[] path;
	int targetIndex;
    public GameObject vision;

	void Start() {
		
	}

    public void PathFindToTarget()
    {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
            print("lol");
            
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

    public delegate void Situation();
    public Situation PathEnd;

    IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
                    if (PathEnd != null)
                    {
                        PathEnd();
                    }
                    yield break;
                    
				}
				currentWaypoint = path[targetIndex];
			}

            var dir = currentWaypoint - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            vision.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
            

            yield return null;

		}
	}
   

    public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one * 0.2f);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}

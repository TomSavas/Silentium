using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public Transform target;
	float speed = 3;
	Vector3[] path;
	int targetIndex;
    public PoliceAI policeAi;

	void Start() {
        policeAi = gameObject.GetComponent<PoliceAI>();
	}

    public void PathFindToTarget()
    {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
            //print("lol");
            
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
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
            if (policeAi != null)
            {
                if (policeAi.seePlayer)
                {
                    var dirt = policeAi.player.transform.position - transform.position;
                    var anglet = Mathf.Atan2(dirt.y, dirt.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(anglet - 90, Vector3.forward);
                }
            }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer {

    bool lol = false;
    static public Transform FindRandomPointInArea(float radius, float min, Vector3 startingPosition, Grid grid)
    {
        GameObject temp = new GameObject();
        search:
        temp.transform.position = new Vector3( startingPosition.x, startingPosition.y);
        Vector2 tempV = Random.insideUnitCircle * radius;
        temp.transform.position += new Vector3(tempV.x, tempV.y, 0);
        Node tempNode = grid.NodeFromWorldPoint(temp.transform.position);
        Debug.Log(tempNode.walkable);
        if (!tempNode.walkable || Vector3.Distance(startingPosition, temp.transform.position)<min) goto search;
        else return temp.transform;
    }
   
}

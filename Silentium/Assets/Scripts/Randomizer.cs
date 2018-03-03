using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer {

    static public Transform FindRandomPointInArea(float radius, Grid grid)
    {
        GameObject temp = new GameObject();
        search:
            temp.transform.position = Random.insideUnitCircle * radius;
            Node tempNode = grid.NodeFromWorldPoint(temp.transform.position);
        if (!tempNode.walkable) goto search;
        else return temp.transform;
    }
}

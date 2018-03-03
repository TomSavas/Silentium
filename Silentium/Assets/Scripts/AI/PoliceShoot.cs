using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceShoot : MonoBehaviour {

    bool canSeePlayer=false;
    float timeToShoot = 0;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update() {
        int layer1 = 8;
        int layer2 = 11;
        int layermask1 = 1 << layer1;
        int layermask2 = 1 << layer2;
        int finalmask = layermask1 | layermask2;
        //Debug.DrawRay(transform.position, transform.up * 5, Color.red, 0.5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 10, finalmask);
        if (hit == true)
        {
            print("i see you");
            if(hit.collider.gameObject.tag=="Player") canSeePlayer = true;
        }
        else canSeePlayer = false;

        if (canSeePlayer)
        {
            timeToShoot += Time.deltaTime;
        }
        else timeToShoot = 0;

        if (timeToShoot>1)
        {
            print("DEAD");
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceShoot : MonoBehaviour {

    bool canSeePlayer=false;
    float shootCooldown = 0;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update() {
        shootCooldown -= Time.deltaTime;

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

        if (canSeePlayer && shootCooldown<0)
        {
            GameObject temp = Instantiate(bullet,new Vector3(transform.position.x, transform.position.y), Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + 90));
            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
            //Physics2D.IgnoreCollision(temp.GetComponent<BoxCollider2D>(), gameObject.GetComponentInChildren<BoxCollider2D>(), true);
            shootCooldown = 1f;
        }
	}
}

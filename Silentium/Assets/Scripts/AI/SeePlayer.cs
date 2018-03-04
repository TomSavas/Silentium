using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour {

    public PoliceAI Police;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Police.Chase();
            Police.seePlayer = true;
        }
        else Police.seePlayer = false;

        if (other.gameObject.CompareTag("Body"))
        {

        }
    }
}

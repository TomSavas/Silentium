using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    public PoliceAI Police;

    private void OnParticleCollision(GameObject particle)
    {
        if (particle.CompareTag("Sound"))
        {
            Police.Chase();
        }
    }
}

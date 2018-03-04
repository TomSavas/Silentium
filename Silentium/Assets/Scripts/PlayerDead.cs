﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {
    public GameObject deathScreen;
    public float timer = 0;
    bool dead = false;
    float startTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0 && dead)
        {
            deathScreen.SetActive(true);
            
        }

    }
    public void Die()
    {
        print("dead");
        dead = true;
        //gameObject.GetComponent<Animator>().SetBool("Dead", true);
        gameObject.GetComponent<Animator>().Play("Death");
        startTimer = Time.realtimeSinceStartup + 3;
        GameObject[] list = GameObject.FindGameObjectsWithTag("NPC");
        GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacterMovement>().enabled = false;
        foreach (var ai in list)
        {
            ai.GetComponent<PoliceAI>().enabled = false;
            ai.GetComponent<PoliceShoot>().enabled = false;
            ai.GetComponent<CivilianAI>().enabled = false;
        }
        timer = 2;
        //Time.timeScale = 0;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	public AudioSource intro;
	public AudioSource loop;

	// Use this for initialization
	void Start () {
		intro.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!intro.isPlaying && !loop.isPlaying) {
			loop.Play ();
		}
	}
}

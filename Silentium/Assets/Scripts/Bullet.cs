using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {


    public GameObject Player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 20 * Time.deltaTime);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerDead>().Die();
            Destroy(gameObject);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public int points = 100;//how many points this collectable is worth

    private PlayerController pc;

	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            pc.addPoints(points);
        }
        Destroy(this.gameObject);
    }
}

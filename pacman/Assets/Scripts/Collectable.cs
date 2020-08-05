using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    private PlayerController PlayerController;

    //points to give the player
    public int points = 100;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerController>().addPoints(points);
            Destroy(this.gameObject);
        }
    }
}

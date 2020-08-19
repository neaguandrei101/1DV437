using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Collectable : MonoBehaviour {

    public int points = 100;//how many points to give the player upon collection
    public AudioClip collectSound;
    public static AudioMixer audioMixer;
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            collected(coll);
        }
    }

    protected virtual void collected(Collider2D coll) {
        coll.gameObject.GetComponent<PlayerController>().addPoints(points);
        if(this != null){
            AudioSource.PlayClipAtPoint(collectSound, transform.position,PlayerPrefs.GetFloat("volume", 1)); 
        } 
        gameObject.SetActive(false);
    }
}

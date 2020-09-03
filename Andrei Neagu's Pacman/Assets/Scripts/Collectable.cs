using UnityEngine;

public class Collectable : MonoBehaviour
{

    public int points = 100;//how many points to give the player upon collection
    public AudioClip collectSound;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            collected(coll);
        }
    }

    protected virtual void collected(Collider2D coll)
    {
        coll.gameObject.GetComponent<PlayerController>().addPoints(points);
        GameManager.playPillSound(collectSound);
        gameObject.SetActive(false);
    }
}

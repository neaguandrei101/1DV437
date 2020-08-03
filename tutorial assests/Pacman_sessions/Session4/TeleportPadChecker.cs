using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadChecker : MonoBehaviour
{

    public Vector2 sendTo;//the x value to send objects that enter it

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.transform.position = sendTo;
    }
}

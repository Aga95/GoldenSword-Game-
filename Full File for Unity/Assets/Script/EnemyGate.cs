using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGate : MonoBehaviour {

    public BoxCollider2D BC;
    public BoxCollider2D BC2;




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BC.isTrigger = false;
            BC2.isTrigger = false;
        }
        else
        {
            BC.isTrigger = true;
            BC2.isTrigger = true;
        }
    }
}

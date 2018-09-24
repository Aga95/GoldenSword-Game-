using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<Movement>().TakeDamage(1000);
            }
        }
    }

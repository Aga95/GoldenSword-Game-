using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEnemy : MonoBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform != this.transform)
        {
            other.SendMessage("TakeDamage", damage,SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
            Debug.Log("Du ble truffet av en pil");
        }
    }
}

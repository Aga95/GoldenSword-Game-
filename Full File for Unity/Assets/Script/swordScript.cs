using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

    //public Animator anim;

    Collider2D swordCol;

    public int damage;

    


    // Use this for initialization
    void Start () {
        swordCol = GameObject.Find("Sword").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {

       /* //Melee Attack
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("attack");

        }
        */
    }


  /*  void Attack()
    {
        swordCol.enabled = true;
    }

    void Idle()
    {
        swordCol.enabled = false;
        anim.ResetTrigger("attack");
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

}

using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour {

    private Movement player;
    private float holder;
    private float holder2;
    private int damageSnow = 10;
    private bool waitDamage = false;

    private void Start()
    {
        player = GetComponent<Movement>();
        holder = player.currentHealth;
        holder2 = holder - 1;
    }

    void OnParticleCollision(GameObject other)
    {
        if(!waitDamage)
        {
            SnowBallDamage();
            waitDamage = true;
        }
        else
        {
            StartCoroutine(snowBallTimer());
        }
    }

    IEnumerator snowBallTimer()
    {
        yield return new WaitForSeconds(1);
        waitDamage = false;
    }

    void SnowBallDamage()
    {
        //Debug.Log("Im Hit");
        player.TakeDamage(damageSnow);          
    }

    private bool takenDamage()
    {
        if(holder2 >= holder)
        {
            holder = player.currentHealth;
            holder2 = holder - 1;
            return true;
        }
        else
        {
            return false;
        }
    }

}

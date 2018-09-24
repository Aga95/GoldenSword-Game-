using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour {

    private Movement player;
    private float holder;
    private float holder2;

    private void Start()
    {
        player = GetComponent<Movement>();
        holder = player.currentHealth;
        holder2 = holder - 1;
    }

    void OnParticleCollision(GameObject other)
    {
        if (takenDamage())
        {
            SnowBallDamage(1);
        }
        else
        {
            StartCoroutine("snowBallTimer");
        }
    }

    IEnumerator snowBallTimer()
    {
        yield return new WaitForSeconds(1);

    }

    void SnowBallDamage(int damage)
    {
        Debug.Log("Im Hit");
        player.TakeDamage(damage);
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

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
    }

    private void OnParticleCollision(GameObject other)
    {
        holder = Time.deltaTime;
        holder2 = holder + 2f;
        if(holder >= holder2)
        {

        }
        player.TakeDamage(1);
        Debug.Log("1: " + holder + " 2: " + holder2);
    }

    IEnumerator snowBallTimer()
    {
        yield return new WaitForSeconds(1);
        player.TakeDamage(1);
    }

    private void SnowBallDamage(int damage)
    {
        Debug.Log("Im Hit");
        player.TakeDamage(damage);
    }


}

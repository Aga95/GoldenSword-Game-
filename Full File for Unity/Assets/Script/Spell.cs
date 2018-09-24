using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Spell : MonoBehaviour {

        public Rigidbody2D rb;
        public Vector2 velocity;



        // Use this for initialization
        void Start() {
            rb = GetComponent<Rigidbody2D>();
            velocity = rb.velocity;
        }



        // Update is called once per frame
        void Update() {

        }


        void OnCollisionEnter2D(Collision2D col)
        {            
            if (col.gameObject.tag == "Enemy")
            {
                int dmg = PlayerPrefs.GetInt("playerLvl") + 2;
                col.gameObject.SendMessage("TakeDamage", dmg);
                Explode();
            }
            else if (col.gameObject.tag == "Player")
            {
                //Explode();
            }
            else
            {
                Explode();
            }
        }

        void Explode()
        {
            Destroy(this.gameObject);
        }

    }
}

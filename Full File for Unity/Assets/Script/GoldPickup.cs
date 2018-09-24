using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class GoldPickup : MonoBehaviour {

        public int value;
        private MoneyManager theMM;
        public AudioClip aCoin;
        public AudioSource aSource;

	    // Use this for initialization
	    void Start () {
            theMM = FindObjectOfType<MoneyManager>();
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name == "Player")
            {
                theMM.AddMoney(value);
                aSource.PlayOneShot(aCoin);
                Destroy(gameObject);
            }
        }

    }
}

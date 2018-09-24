using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJump : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DestroyCloud();
        }
        
    }
   
    

    void DestroyCloud()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreak : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("iceBreak");            
        }

    }

    IEnumerator iceBreak()
    {
        yield return new WaitForSeconds(1);
        DestroyIce();
    }


    
    void DestroyIce()
    {
        Destroy(this.gameObject);
    }
}

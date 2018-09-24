using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJump : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            WaitForSeconds(1).Destroy(gameObject);
        }
    }
}

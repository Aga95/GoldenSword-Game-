using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryedOpenPath : MonoBehaviour {
    public GameObject[] blocks;

    private void OnDestroy()
    {
        foreach (GameObject go in blocks)
        {
            Destroy(go);
        }
    }
}

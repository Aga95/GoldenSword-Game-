using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnW4 : MonoBehaviour
{
    public string chck;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt(chck) > 0)
        {
            this.gameObject.GetComponentInChildren<Text>().text = "Equip";
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt(chck) > 0)
        {
            this.gameObject.GetComponentInChildren<Text>().text = "Equip";
        }
    }
}

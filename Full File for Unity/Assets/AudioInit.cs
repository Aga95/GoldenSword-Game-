using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInit : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float vol = PlayerPrefs.GetFloat("VolMusic");
        AudioListener.volume = vol;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

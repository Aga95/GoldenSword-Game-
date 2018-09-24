using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControllerMusic : MonoBehaviour {

    public Slider musicSlider;
    private float tmpVolume;
    public Button musicButton;
    private float V;

    private void Awake()
    {
        if(PlayerPrefs.GetFloat("VolMusic") > 0)
        {
            //set the current volume and times it by 10 so it can be applied to the slider.
            V = PlayerPrefs.GetFloat("VolMusic") * 10;
        }
        else
        {
            V = 10;
        }
        
        //if the volume is 0 then the button should say that the sound is off
        if (V == 0)
        {
            buttonOff();
        }
        //Define the slider to be equals to the value of the current volume.
        musicSlider.value = V;
        setGlobalVolumeEffects(V);

    }

    public void setVolumeLevel()
    {
        float V = musicSlider.value / 10;
        AudioListener.volume = V;
        setGlobalVolumeEffects(V);

        if (V == 0)
        {
            buttonOff();
        }
        else
        {
            buttonOn();
        }
    }

    public void ToggleMuteButton()
    {
        string checkText = musicButton.gameObject.GetComponentInChildren<Text>().text;
        if (checkText == "Music Off")
        {
            buttonOn();
            AudioListener.volume = tmpVolume;
            musicSlider.value = tmpVolume * 10;
        }
        else
        {
            buttonOff();
            tmpVolume = AudioListener.volume;
            setGlobalVolumeEffects(tmpVolume);
            AudioListener.volume = 0.0f;
            musicSlider.value = 0;
        }
    }

    void buttonOff(){
        musicButton.gameObject.GetComponentInChildren<Text>().text = "Music Off";
    }
    void buttonOn()
    {
        musicButton.gameObject.GetComponentInChildren<Text>().text = "Music On";
    }
    void setGlobalVolumeEffects(float vol)
    {
        PlayerPrefs.SetFloat("VolMusic", vol);
    }
}

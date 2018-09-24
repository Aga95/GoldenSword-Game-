using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControllerEffects : MonoBehaviour {
    public Slider effectsSlider;
    private float tmpVolume;
    public Button effectsButton;

    private void Awake()
    {
        //set the current volume and times it by 10 so it can be applied to the slider.
        float V = PlayerPrefs.GetFloat("VolEffects") * 10;
        //if the volume is 0 then the button should say that the sound is off
        if (V == 0)
        {
            buttonOff();
        }
        //Define the slider to be equals to the value of the current volume.
        effectsSlider.value = V;
        setGlobalVolumeEffects(V);

    }

    public void setVolumeLevel()
    {
        float V = effectsSlider.value / 10;
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
        string checkText = effectsButton.gameObject.GetComponentInChildren<Text>().text;
        if (checkText == "Effects Off")
        {
            buttonOn();
            AudioListener.volume = tmpVolume;
            effectsSlider.value = tmpVolume * 10;
        }
        else
        {
            buttonOff();
            tmpVolume = AudioListener.volume;
            setGlobalVolumeEffects(tmpVolume);
            AudioListener.volume = 0.0f;
            effectsSlider.value = 0;
        }
    }

    void buttonOff()
    {
        effectsButton.gameObject.GetComponentInChildren<Text>().text = "Effects Off";
    }
    void buttonOn()
    {
        effectsButton.gameObject.GetComponentInChildren<Text>().text = "Effects On";
    }
    void setGlobalVolumeEffects(float vol)
    {
        PlayerPrefs.SetFloat("VolEffects", vol);
    }
}

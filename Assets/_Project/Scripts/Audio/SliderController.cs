using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;
    public float oldVolume;

    private void Start()
    {
        slider = GetComponent<Slider>();
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey("volume")) slider.value = 1;
        else slider.value = PlayerPrefs.GetFloat("volume");
        if (PlayerPrefs.GetInt("audioTrue") == 0)
            PlayerPrefs.SetFloat("volume", 1);
        PlayerPrefs.SetInt("audioTrue", 1);
    }
    private void Update()
    {
        if (oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
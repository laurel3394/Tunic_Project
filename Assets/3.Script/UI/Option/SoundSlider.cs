using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider BGMslider;
    [SerializeField] private Slider SFXslider;


    private void Start()
    {
        BGMslider.maxValue = 1f;
        SFXslider.maxValue = 1f;

        BGMslider.value = AudioManager.instance.bgmVolume;
        SFXslider.value = AudioManager.instance.sfxVolume;
    }

    public void Update()
    {
        AudioManager.instance.bgmVolume = BGMslider.value;
        AudioManager.instance.sfxVolume = SFXslider.value;


    }
}
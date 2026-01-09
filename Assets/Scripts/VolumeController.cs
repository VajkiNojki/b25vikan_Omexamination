using UnityEngine;
using UnityEngine.Audio; // Behövs för AudioMixer
using UnityEngine.UI;    // Behövs för Slider

public class VolumeController : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMusicVolume(float sliderValue)
    {
        // Vi omvandlar linjärt värde (0-1) till Logaritmiskt (decibel)
        masterMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVolume(float sliderValue)
    {
        masterMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider MusicSlider;
    public Slider GlobalSlider;

    [Header("Audio Elements")]
    public AudioSource doorOpenSound;
    public AudioSource walkSound;
    public AudioSource environmentSound;
    public AudioSource deadSound;

    private const string GlobalPrefKey = "GlobalVolumePreference";
    private const string MusicPrefKey = "MusicVolumePreference";

    private void Start()
    {
        // �nceden kaydedilen ses seviyelerini y�kle
        float savedGlobalVolume = PlayerPrefs.GetFloat(GlobalPrefKey, 0.5f); // Varsay�lan 0.5
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicPrefKey, 0.5f); // Varsay�lan 0.5

        GlobalSlider.value = savedGlobalVolume;
        MusicSlider.value = savedMusicVolume;

        // Ses seviyelerini ayarla
        SetGlobalVolume(savedGlobalVolume);
        SetMusicVolume(savedMusicVolume);

        // Sliderlar�n de�er de�i�iminde ilgili fonksiyonlar� �a��r
        GlobalSlider.onValueChanged.AddListener(SetGlobalVolume);
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    // Global ses seviyesini ayarlama fonksiyonu
    public void SetGlobalVolume(float volume)
    {
        doorOpenSound.volume = volume;
        walkSound.volume = volume;

        // Global ses seviyesini kaydet
        PlayerPrefs.SetFloat(GlobalPrefKey, volume);
    }

    // M�zik ve �evre seslerinin seviyesini ayarlama fonksiyonu
    public void SetMusicVolume(float volume)
    {
        environmentSound.volume = volume;
        deadSound.volume = volume;

        // M�zik ses seviyesini kaydet
        PlayerPrefs.SetFloat(MusicPrefKey, volume);
    }

    public void PlayDoorOpenSound()
    {
        doorOpenSound.Play();
    }

    public void PlayWalkSound()
    {
        if (!walkSound.isPlaying)
        {
            walkSound.Play();
        }
    }

    public void StopWalkSound()
    {
        walkSound.Stop();
    }

    public void PlayGameEndingSound()
    {
        deadSound.Play();
    }
}

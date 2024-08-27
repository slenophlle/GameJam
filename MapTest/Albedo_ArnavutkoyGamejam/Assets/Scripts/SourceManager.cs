using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider volumeSlider;

    [Header("Audio Elements")]
    public AudioSource audioSource;

    private const string VolumePrefKey = "VolumePreference"; // PlayerPrefs için anahtar

    private void Start()
    {
        // Saklanan ses seviyesini al ve slider ile ses seviyesini ayarla
        if (volumeSlider != null && audioSource != null)
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1f); // Varsayýlan deðer 1
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;

            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefKey, volume); // Deðeri sakla
        PlayerPrefs.Save(); // Veriyi diske kaydet
    }
}
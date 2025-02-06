using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    private const string VolumePrefKey = "VolumeLevel";

    void Start()
    {
        // Ensure the slider and AudioSource volume match the saved value
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1.0f);
        volumeSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        // Remove old listeners to avoid duplicates
        volumeSlider.onValueChanged.RemoveAllListeners();

        // Add a listener to call the method when the slider value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSliderMusic;
    [SerializeField] private Slider volumeSliderSFX;

    private string MusicVolumeKey = "MusicVolume";
    private string SFXVolumeKey = "SFXVolume";
    private bool isOpen;

    void Start()
    {
        LoadVolumes();
    }

    public void SetMusicVolume()
    {
        float volume = volumeSliderMusic.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void SetSFXVolume()
    {
        float volume = volumeSliderSFX.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }

    public void LoadLevel(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);
    }

    public void OpenSettings(GameObject settings)
    {
        isOpen = !isOpen;
        settings.SetActive(isOpen);
        if (isOpen == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void LoadVolumes()
    {
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            volumeSliderMusic.value = savedMusicVolume;
            audioMixer.SetFloat("Music", Mathf.Log10(savedMusicVolume) * 20);
        }

        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
            volumeSliderSFX.value = savedSFXVolume;
            audioMixer.SetFloat("SFX", Mathf.Log10(savedSFXVolume) * 20);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
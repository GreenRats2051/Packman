using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSliderMusic;
    public Slider volumeSliderSFX;

    public void SetMusicVolume()
    {
        float volume = volumeSliderMusic.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = volumeSliderSFX.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void LoadLevel(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);
    }
}
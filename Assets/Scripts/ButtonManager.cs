using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSliderMusic;
    public Slider volumeSliderSFX;

    private void Start()
    {
        float currentVolume = 50f;
        audioMixer.GetFloat("Music", out currentVolume);
        volumeSliderMusic.value = Mathf.Pow(10, currentVolume / 20);
        audioMixer.GetFloat("SFX", out currentVolume);
        volumeSliderSFX.value = Mathf.Pow(10, currentVolume / 20);
    }

    public void LoadLevel(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
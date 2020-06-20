using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    int setQualityIndex = 1;
    public Dropdown graphics;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex+1);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex + 1);
    }

    private void Start()
    {
        setQualityIndex = PlayerPrefs.GetInt("qualityIndex", 2);
        QualitySettings.SetQualityLevel(setQualityIndex);
        graphics.value = setQualityIndex;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public GameObject settingsMenuUI;
    public GameObject videoSettingsUI;
    public GameObject audioSettingsUI;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string resOption = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(resOption);

            if (resolutions[i].width == Screen.width
                && resolutions[i].height == Screen.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /*----- Video Settings -----*/
    public void ToggleVideoSettings() {
        settingsMenuUI.SetActive(!settingsMenuUI.activeSelf);
        videoSettingsUI.SetActive(!videoSettingsUI.activeSelf);
    }

    public void SetFullscreen (bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    /*----- Audio Settings -----*/
    public void ToggleAudioSettings() {
        settingsMenuUI.SetActive(!settingsMenuUI.activeSelf);
        audioSettingsUI.SetActive(!audioSettingsUI.activeSelf);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

}

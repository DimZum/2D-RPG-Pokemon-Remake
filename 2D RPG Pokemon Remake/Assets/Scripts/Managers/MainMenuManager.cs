using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    public SceneFader sceneFader;
    public AudioManager audioManager;

    public GameObject mainMenuButtons;
    public GameObject settingsUI;

    private void Start() {
        audioManager = AudioManager.instance;

        audioManager.Play(ResourceManager.mainMenuTheme);
    }

    // Start a new game file
    public void NewGame() {

    }
    
    // Load a save file
    public void LoadGame() {

    }

    // Settings menu
    public void ToggleSettings() {
        mainMenuButtons.SetActive(!mainMenuButtons.activeSelf);
        settingsUI.SetActive(!settingsUI.activeSelf);
    }

    // Quit the game
    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

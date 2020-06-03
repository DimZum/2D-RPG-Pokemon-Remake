using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public SceneFader sceneFader;

    public GameObject pauseMenuUI;

    // Resume button
    public void Resume() {
        if (pauseMenuUI != null) {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        }
    }

    // Open subset of options when opened (ie. sound)
    public void Settings() {

    }

    // Saves the game
    public void Save() {

    }

    // Exits the game and returns to the main menu screen
    public void ExitToMainMenu() {
        sceneFader.FadeTo(SceneFader.mainMenuSceneName);
    }

    // Exits the game
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour {

    public GameObject optionsMenuUI;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Check if ESC key was pressed
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Toggle options menu
            optionsMenuUI.SetActive(!optionsMenuUI.activeSelf);
        }
    }

    // Resume button
    public void Resume() {

    }

    // Open subset of options when opened (ie. sound)
    public void Options() {

    }

    // Saves the game
    public void Save() {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Holds references to resources that are used more than once
public class ResourceManager : MonoBehaviour {

    /* SINGLETON */
    /*#region SINGLETON
    public static ResourceManager instance;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion*/

    // Sounds
    // Names of sound files
    public static string mainMenuTheme = "MainMenuTheme";

    // Fonts
    public static Font ff3_font;
}

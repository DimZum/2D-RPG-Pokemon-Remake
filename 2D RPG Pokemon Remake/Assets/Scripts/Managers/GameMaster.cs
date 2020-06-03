using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    /* SINGLETON */
    #region SINGLETON
    public static GameMaster instance;

    public void Awake() {
        if (instance == null) {
            //instance = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            instance = this;
        }
    }
    #endregion

    //private AudioManager audioManager;

    //public GameOVerUI gameOverUI;
    public GameObject PauseMenuUI;

    public static bool isGameOver;
    public static bool isGamePaused;

    // Start is called before the first frame update
    void Start() {
        isGamePaused = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if (PauseMenuUI != null) {
            // Check if ESC key was pressed
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // Toggle options menu
                PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
            }
        }
    }

    public void EndGame() {
        isGameOver = true;
        // start game over ui
    }
}

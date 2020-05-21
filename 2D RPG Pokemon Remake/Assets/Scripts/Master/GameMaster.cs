using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    /* SINGLETON */
    #region SINGLETON
    public static GameMaster instance;

    public void Awake() {
        if (instance == null) {
            instance = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    #endregion

    //private AudioManager audioManager;

    //public GameOVerUI gameOverUI;
    //public PauseMenu pauseMenu;

    public static bool isGameOver;
    public static bool isGamePaused;

    // Start is called before the first frame update
    void Start() {
        isGamePaused = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void EndGame() {
        isGameOver = true;
        // start game over ui
    }
}

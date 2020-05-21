using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singleton
    public static PlayerManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject player;
    public PlayerStats playerStats;

    public int gold;

    // Initialize player stats and etc.
    private void Start() {
        gold = 15;


    }

    public void KillPlayer() {
        Debug.Log("You have died!");
    }
}

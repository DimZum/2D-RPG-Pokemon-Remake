using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuUI : MonoBehaviour {

    public Transform inventoryUI;
    public GameObject playerMenuUI;

    /*--- References to Text objects to display player stats/equips ---*/
    // Info on the player (ie. name, lvl, & class)
    public Text ign_t;                  // Player's ign
    public Text lvl_t;                  // Player's level
    public Text class_t;                // Player's class
    public Text Gold_t;                 // Player's gold

    // Player's current stats
    public Text hp_t;                   // Health points
    public Text mp_t;                   // Mana points

    public Text attack_t;               // Attack
    public Text defense_t;              // Defense
    public Text int_t;                  // Intelligence
    public Text md_t;                   // Magic Defense
    public Text cc_t;                   // Crit Chance
    public Text cd_t;                   // Crit Damage

    // Player's current equipped items
    public Text rHand_t;                // Right hand equipment
    public Text rLeft_t;                // Left hand equipment
    public Text head_t;                 // Head armor
    public Text body_t;                 // Body armor
    public Text legs_t;                 // Leg armor
    public Text boots_t;                // ie. boots
    public Text acc1_t;                 // Accessory #1
    public Text acc2_t;                 // Accessory #2

    Inventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        // Populate slots array
        slots = inventoryUI.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update() {
        // 'c' to toggle player status
        if (Input.GetKeyDown(KeyCode.C)) {
            playerMenuUI.SetActive(!playerMenuUI.activeSelf);
        }
    }

    void UpdateUI() {
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
}

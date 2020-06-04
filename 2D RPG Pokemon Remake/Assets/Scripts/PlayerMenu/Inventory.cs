using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if (instance != null) {
            Debug.Log("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion
    
    // Triggered when item is added/removed
    public delegate void OnItemChagned();
    public OnItemChagned onItemChangedCallback;

    public int numSlots = 28; // Number of slots in inventory
    public List<Item> items = new List<Item>(); // Current list of item in inventory

    // Adds item to inventory
    // Returns true if successful, else false
    public bool Add(Item item) {
        if (items.Count >= numSlots) {
            Debug.Log("Inventory is full.");
            return false;
        }

        items.Add(item);

        // Trigger callback
        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    // Remove desired item
    public void Remove(Item item) {
        items.Remove(item);

        // Trigger callback
        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }
}

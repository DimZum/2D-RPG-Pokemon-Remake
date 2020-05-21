using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;              // Reference to the Icon image
    public Button removeButton;     // Reference to the remove button

    Item item;                      // Current item in the slot

    // Add an item to the slot
    public void AddItem(Item newItem) {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.enabled = true;
    }

    public void ClearSlot() {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.enabled = false;
    }

    public void OnRemoveButton() {
        Inventory.instance.Remove(item);
    }

    public void UseItem() {
        if (item != null) {
            item.Use();
        }
    }
}

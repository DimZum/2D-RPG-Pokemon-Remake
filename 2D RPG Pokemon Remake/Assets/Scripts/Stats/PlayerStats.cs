using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {
        
    // Start is called before the first frame update
    void Start() {
        CurrentHealth = (int)maxHealth.GetValue();
    }

    //void OnEquipmentChagned(Equipment newItem, Equipment oldItem) {

    //}

    public override void Die() {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}

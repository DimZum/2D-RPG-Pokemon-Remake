using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat maxHealth;
    public int CurrentHealth { get; set; }
    public Stat mana;

    public Stat attack;
    public Stat defense;
    public Stat intelligence;
    public Stat magicDefense;

    public Stat CritChance;
    public Stat CritDamage;

    // Handles physical damage
    public void TakePDamage(float p_damage) {
        // Reduce incoming physical damage by armor amount
        p_damage -= defense.GetValue();
        p_damage = Mathf.Clamp(p_damage, 0, int.MaxValue); // Ensures physical damage can't be below 0

        CurrentHealth -= (int)Mathf.Round(p_damage);

        // Check if health reaches zero
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    // Handles magical damage
    public void TakeMDamage(float m_damage) {
        // Reduce incoming physical damage by armor amount
        m_damage -= magicDefense.GetValue();
        m_damage = Mathf.Clamp(m_damage, 0, int.MaxValue); // Ensures magical damage can't be below 0

        CurrentHealth -= (int)Mathf.Round(m_damage);

        // Check if health reaches zero
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        Debug.Log(transform.name + " died. ");
    }
}

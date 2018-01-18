using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat {
    
	// Use this for initialization
	void Start () {
        EquipmentManager.instance.onEquipmentChange += OnEquipmentChange;
	}

    void OnEquipmentChange(Equipment newItem, Equipment prevousItem)
    {
        //newItem.armorModifier = (int)(newItem.EquipmentLevelModifier * 1.5f) + newItem.baseArmor;
        //newItem.damageModifier = (int)(newItem.EquipmentLevelModifier * 3.0f) + newItem.baseDamage;
        //newItem.healthModifier = (int)(newItem.EquipmentLevelModifier * 10.0f) + newItem.baseHealth;

        if (newItem != null)
        {
            //health.AddModifier(newItem.healthModifier);
            //armor.AddModifier(newItem.armorModifier);
            //damage.AddModifier(newItem.damageModifier);

            health.AddModifier((int)(newItem.EquipmentLevelModifier * newItem.healthModifier) + newItem.baseHealth);
            armor.AddModifier((int)(newItem.EquipmentLevelModifier * newItem.armorModifier) + newItem.baseArmor);
            damage.AddModifier((int)(newItem.EquipmentLevelModifier * newItem.damageModifier) + newItem.baseDamage);
        }

        if (prevousItem != null)
        {
            health.RemoveModifier((int)(prevousItem.EquipmentLevelModifier * prevousItem.healthModifier) + prevousItem.baseHealth);
            armor.RemoveModifier((int)(prevousItem.EquipmentLevelModifier * prevousItem.armorModifier) + prevousItem.baseArmor);
            damage.RemoveModifier((int)(prevousItem.EquipmentLevelModifier * prevousItem.damageModifier) + prevousItem.baseDamage);
        }
    }


    public override void Die()
    {
        base.Die();

        PlayerManager.instance.KillPlayer();
    }
}

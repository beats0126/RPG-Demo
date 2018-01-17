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
        if (newItem != null)
        {
            health.AddModifier(newItem.healthModifier);
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (prevousItem != null)
        {
            health.RemoveModifier(prevousItem.healthModifier);
            armor.RemoveModifier(prevousItem.armorModifier);
            damage.RemoveModifier(prevousItem.damageModifier);
        }
    }


    public override void Die()
    {
        base.Die();

        PlayerManager.instance.KillPlayer();
    }
}

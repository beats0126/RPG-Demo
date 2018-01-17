using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;

    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegion;
    
	public int armorModifier;
    public int damageModifier;
    public int healthModifier;

    public override void Use()
    {
        base.Use();
        RemoveFromInventory();
        EquipmentManager.instance.AddToEquip(this, this);
        //EquipmentManager.instance.Equip(this);
    }

}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Feet
}

public enum EquipmentMeshRegion
{
    Legs,
    Arms,
    Torse
}
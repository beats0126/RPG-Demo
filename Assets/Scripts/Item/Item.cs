﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    Item equipment;

    public virtual void Use()
    {
        //Debug.Log("Using : " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public void AddToEquipment()
    {
        //EquipmentManager.instance.AddToEquip(this, this);
    }
}

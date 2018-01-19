using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region Private Variable

    private EquipmentSocket[] equipSlots;
    private Item[] equips;
    private List<Item> equip = new List<Item>();

    private Equipment[] currentEquipment;
    private SkinnedMeshRenderer[] currentMeshes;

    private Inventory inventory;

    #endregion

    #region Public Variable

    public Transform equipParent;
    public GameObject EquipmentUI;
    public Equipment[] defaultItem;
    public SkinnedMeshRenderer targetMesh;

    public GameObject notification;
    public Text notice;

    public int space;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment prevousItem);
    public OnEquipmentChanged onEquipmentChange;

    public delegate void OnEquipChangeCallBack();
    public OnEquipChangeCallBack onEquipChangeCallBack;

    #endregion

    #region Function

    void Start () {
        inventory = Inventory.instance;
        onEquipChangeCallBack += UpdateEquipUI;

        equipSlots = equipParent.GetComponentsInChildren<EquipmentSocket>();

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        equips = new Item[numSlots];

        EquipDefaultItem();

        // give the index number to every Equipment Slot for easy fill up slot when equip and unequip it.
        for(int i = 0; i < equipSlots.Length; i++)
        {
            equipSlots[i].index = i;
        }
	}

    // Equip item, using int to remove item from inventory list and add to equipment list
    // it will auto fill item into certain position of item
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment prevousItem = Unequip(slotIndex);

        if(onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, prevousItem);
        }

        SetEquipmentBlendShapes(newItem, 100);

        currentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        currentMeshes[slotIndex] = newMesh;
    }

    // same logic with equip item
    public Equipment Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment prevousItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(prevousItem, 0);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, prevousItem);
            }
            return prevousItem;
        }
        return null;    
    }

    public void UnequipAll()
    {
        equip.Clear();
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItem();
        UpdateEquipUI();
    }

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach(EquipmentMeshRegion blendShape in item.coveredMeshRegion)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    // default item
    void EquipDefaultItem()
    {
        foreach(Equipment item in defaultItem)
        {
            Equip(item);
        }
    }

    // add to equipmentUI, change meshes
    public bool AddToEquip(Item item, Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        if(equips[slotIndex] != null)
        {
            Equipment prevousItem = Unequip(slotIndex);

            RemoveFromEquip(prevousItem, slotIndex);

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(newItem, prevousItem);
            }

            equips[slotIndex] = newItem;

            SetEquipmentBlendShapes(newItem, 100);

            currentEquipment[slotIndex] = newItem;

            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;

            currentMeshes[slotIndex] = newMesh;
        }
        else
        {
            Equipment prevousItem = Unequip(slotIndex);

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(newItem, prevousItem);
            }

            equips[slotIndex] = newItem;

            SetEquipmentBlendShapes(newItem, 100);

            currentEquipment[slotIndex] = newItem;

            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;

            currentMeshes[slotIndex] = newMesh;
        }

        if (onEquipChangeCallBack != null)
           onEquipChangeCallBack.Invoke();
       
        return false;
        
    }

    //Remove Equipment from equipmentUI and add back inventory, reset back the meshes and list
    public void RemoveFromEquip(Item item, int index)
    {
        if (inventory.items.Count >= inventory.space)
        {
            notification.GetComponent<NotificationManager>().displayAble = true;
            notice.text = "Inventory FULL, cannot unequip now";
            //Debug.Log("Inventory FULL, cannot unequip");
        }
        else
        {
            inventory.Add(item);
            Unequip(index);

            Equip(defaultItem[index]);

            equips[index] = null;
            equipSlots[index].ClearSlot();
        }

        if (onEquipChangeCallBack != null)
            onEquipChangeCallBack.Invoke();
    }
    
    void UpdateEquipUI()
    {
        for (int i = 0; i < equips.Length; i++)
        {

            if (i < equips.Length)
            {
                if (equips[i] == null)
                    continue;

                equipSlots[i].AddToEquip(equips[i]);
            }
            else
            {
                equipSlots[i].ClearSlot();
            }
        }
    }

    #endregion
}

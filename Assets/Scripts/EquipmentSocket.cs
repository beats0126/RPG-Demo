using UnityEngine;
using UnityEngine.UI;

public class EquipmentSocket : MonoBehaviour {

    public Image icon;
    public GameObject gameManager;
    EquipmentManager manager;
    public int index;

    Item item;

    private void Awake()
    {
        manager = gameManager.GetComponent<EquipmentManager>();
    }

    public void AddToEquip(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void RemoveButton()
    {
        manager.RemoveFromEquip(item, index);
    }
}

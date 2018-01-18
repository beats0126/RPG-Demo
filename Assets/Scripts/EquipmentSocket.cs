using UnityEngine;
using UnityEngine.UI;

public class EquipmentSocket : MonoBehaviour {

    public Image icon;
    public GameObject gameManager;
    EquipmentManager manager;
    public int index;

    public Sprite temp;

    Item item;

    private void Awake()
    {
        manager = gameManager.GetComponent<EquipmentManager>();
        temp = icon.sprite;
    }

    public void AddToEquip(Item newItem)
    {
        item = newItem;
       
        icon.sprite = item.icon;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = temp;
    }

    public void RemoveButton()
    {
        manager.RemoveFromEquip(item, index);
    }
}

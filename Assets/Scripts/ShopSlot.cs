using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour {
    
    public Image icon;
    public Text names;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        names.text = newItem.name;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        names.text = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void onClickAddToInventory()
    {
        Inventory.instance.Add(item);

        ClearSlot();
    }
}

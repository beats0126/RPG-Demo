using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("gg inventory");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallBack;

    public GameObject notification;
    public Text notice;

    public int space = 20;

    public List<Item> items = new List<Item>();

    // add item to list
    public bool Add(Item item)
    {
        // check it is a equipment not custom clothes
        if(!item.isDefaultItem)
        {
            if(items.Count >= space) {
                notification.GetComponent<NotificationManager>().displayAble = true;
                notice.text = "Inventory Full, cannot pickup!";
                //Debug.Log("Inventory FULL");
                return false;
            }

            items.Add(item);

            if(onItemChangeCallBack != null)
              onItemChangeCallBack.Invoke();
        }

        return true;
    }

    // remove item from list
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallBack != null)
            onItemChangeCallBack.Invoke();
    }
}

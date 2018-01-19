using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Transform shopParent;

    private List<Transform> shopSlot = new List<Transform>();

    public List<Item> itemList = new List<Item>();
    //public Item[] items;

    // Use this for initialization
    void Awake ()
    {
        foreach (Transform slot in shopParent)
        {
            shopSlot.Add(slot);
        }
	}

    private void Start()
    {
        
    }

    public void UpdateShopContent()
    {
        for (int i = 0; i < shopSlot.Count; i++)
        {
            int num = Random.Range(0, itemList.Count);
            Debug.Log(num);
            shopSlot[i].GetComponent<ShopSlot>().AddItem(itemList[num]);
            Debug.Log(shopSlot[i].name);
        }
    }
}

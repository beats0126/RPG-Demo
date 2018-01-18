using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : Interactable {

    public GameObject shopUI;
    ShopManager _shopManager;

    private void Awake()
    {
        _shopManager = shopUI.GetComponent<ShopManager>();
    }

    public override void Interact()
    {
        base.Interact();

        onCallShopUI();
        _shopManager.UpdateShopContent();
    }
    
    public void onCallShopUI()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }
}

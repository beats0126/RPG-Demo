using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {

    #region Public Variable

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject equipmentUI;
    public GameObject settingUI;

    #endregion

    #region Private Variable

    Inventory inventory;

    InventorySlot[] slots;

    #endregion

    #region Function
    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        if (Input.GetButtonDown("Equipment"))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            equipmentUI.SetActive(false);
            inventoryUI.SetActive(false);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    #endregion

    #region Button Function

    public void onCallEquipmentUI()
    {
        equipmentUI.SetActive(!equipmentUI.activeSelf);
    }

    public void onCallInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void onCallSettingUI()
    {
        settingUI.SetActive(!settingUI.activeSelf);
    }

    public void onExitGameButton()
    {
        Application.Quit();
    }

    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateEquipment : Editor{

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    // instantiate helmet with custom attribute on item
    public void CreateAsset(Equipment equip)
    {
        equip = new Equipment();
        int folderName = Random.Range(0, 100000000);
        AssetDatabase.CreateAsset(equip, "Assets/Tempdata/" + folderName + ".asset");
    }
}

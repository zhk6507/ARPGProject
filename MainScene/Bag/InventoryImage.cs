using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryImage : MonoBehaviour {

    public List<InventoryItemImage> itemList = new List<InventoryItemImage>();


    void Start()
    {
        //将事件进行注册
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
    }

    void Destory()
    {
        //将事件进行注销
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;
    }

    void OnInventoryChange()
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            itemList[i].SetInventoryItem(InventoryManager._instance.inventoryItemList[i]);
        }
    }
}

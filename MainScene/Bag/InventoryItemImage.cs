using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItemImage : MonoBehaviour {

    //控制每个背包格子上图片和数量的显示
    public Image inventoryItemImage;
    public Text inventoryItemText;
    private InventoryItem it;

    //设置背包格子显示
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        //改变图片与数量的显示 
        inventoryItemImage.overrideSprite = Resources.Load(it.Inventory.Image, typeof(Sprite)) as Sprite;
        if (it.Count<=1)
        {
            inventoryItemText.text = "";
        }
        else
        {
            inventoryItemText.text = it.Count.ToString();
        }
        
    }
}

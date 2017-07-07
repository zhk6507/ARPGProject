using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryInBagShow : MonoBehaviour
{
    //获得物品介绍面板的各种属性
    public Text itemName;
    public Image itemImage;
    public Text itemInfo;
    public static int num;
    //获得物品介绍面板
    public GameObject itemInfoWindow;

    //单例模式
    public static InventoryInBagShow _instance;

    public int i;

    void Start()
    {
        _instance = this;
    }

    //物品的点击事件
    public void ItemOnClick()
    {
        itemInfoWindow.SetActive(true);
        InventoryItem it = InventoryManager._instance.inventoryItemList[i];
        itemName.text = it.Inventory.Name;
        itemImage.overrideSprite = Resources.Load(it.Inventory.Image, typeof(Sprite)) as Sprite;
        itemInfo.text = it.Inventory.Des;
        num = it.Count;
        
    }

    public void ShowItemNum() 
    {
        InventoryManager._instance.inventoryItemList[i].Count = num;
    }
}

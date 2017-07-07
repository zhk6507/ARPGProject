using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

    private Inventory inventory;
    private int level = 1;//装备等级
    private int count;//物品个数

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }
}

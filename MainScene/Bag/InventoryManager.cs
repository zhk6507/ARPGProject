using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour
{

    public TextAsset listInfo;
    //新建一个字典，储存每一个创建好的inventory
    public Dictionary<int, Inventory> inventoryDic = new Dictionary<int, Inventory>();
    //新建一个List集合，储存背包里的物品
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    //单例模式
    public static InventoryManager _instance;

    //定义一个事件，每当背包里的物品发生变化，触发这个事件
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;
    void Awake()
    {
        //单例模式赋值
        _instance = this;
        //物品信息的初始化
        ReadInventoryInfo();
        
    }

    void Start()
    {
        //背包的初始化
        ReadInventoryItemInfo();
    }

    void ReadInventoryInfo()
    {
        //接收文档里的内容
        string str = listInfo.ToString();
        //按行将字符串分割
        string[] itemStrArray = str.Split('\n');
        foreach (var item in itemStrArray)
        {
            //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 
            string[] proArray = item.Split('|');//每一行再按照“|”进行分割，得到每一个元素
            Inventory inventory = new Inventory();
            inventory.Id = int.Parse(proArray[0]);
            //Debug.Log(inventory.Id);
            inventory.Name = proArray[1];
            inventory.Image = proArray[2];
            switch (proArray[3])
            {
                case "Equip":
                    inventory.InventoryType = InventoryType.Equipment;
                    break;
                case "Drug":
                    inventory.InventoryType = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryType = InventoryType.Box;
                    break;
            }
            if (inventory.InventoryType == InventoryType.Equipment)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        inventory.EquipType = EquipType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipType = EquipType.Cloth;
                        break;
                    case "Weapon":
                        inventory.EquipType = EquipType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipType = EquipType.Shoes;
                        break;
                    case "Necklace":
                        inventory.EquipType = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipType = EquipType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipType = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipType = EquipType.Wings;
                        break;
                }
            }

            //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
            inventory.Price = int.Parse(proArray[5]);
            //判断是否为装备
            if (inventory.InventoryType == InventoryType.Equipment)
            {
                inventory.StartLevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.Hp = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            //作用类型和作用值是药品的属性
            if (inventory.InventoryType == InventoryType.Drug)
            {
                //目前只有回复HP的药剂，所以不用判断作用类型
                //判断作用值
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            //描述
            inventory.Des = proArray[13];

            //创建好所有的之后传到字典集合里去
            inventoryDic.Add(inventory.Id, inventory);
        }
    }

    //生成背包里的物品
    void ReadInventoryItemInfo()
    {
        //需要连接服务器，获取当前角色所拥有的物品信息 TODO

        //那就随机生成物品放入角色背包
        for (int i = 0; i < 30; i++)
        {
            //物品由ID唯一确定，随机生成ID即为随机生成物品
            int id = Random.Range(1017, 1022);
            Inventory good = null;
            //取得此ID的物品信息，传入新建的inventory good中
            inventoryDic.TryGetValue(id, out good);
            //装备无论是否相同每个占一格，其他物品相同的都放入同一个格子
            if (good.InventoryType == InventoryType.Equipment)
            {
                //新建一个背包InventoryItem储存这个good
                InventoryItem it = new InventoryItem();
                it.Inventory = good;
                it.Level = Random.Range(1, 5);//等级随机生成
                it.Count = 1;
                //把这件物品传入背包字典集合中                
                inventoryItemList.Add(it);

            }
            else
            {
                //不是装备的时候，先判断背包中是否存在这件物品，既遍历List集合
                InventoryItem it = null;
                bool isHave = false;
                foreach (InventoryItem item in inventoryItemList)
                {
                    if (item.Inventory.Id == id)
                    {
                        isHave = true;
                        it = item;
                        break;
                    }
                }
                if (isHave)
                {
                    it.Count++;//存在，个数+1
                }
                else
                {
                    //不存在，把这个物品添加进背包字典集合中
                    it = new InventoryItem();
                    it.Inventory = good;
                    it.Count = 1;
                    inventoryItemList.Add(it);
                }
            }
        }
        OnInventoryChange();
    }
}

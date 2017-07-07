using UnityEngine;
using System.Collections;
public enum InventoryType
{
    Equipment,
    Drug,
    Box//宝箱
}

public enum EquipType
{
    Helm,//头盔
    Cloth,//衣服
    Weapon,//武器
    Shoes,//鞋子
    Necklace,//项链
    Bracelet,//手镯
    Ring,//戒指
    Wings//翅膀
    
}

public class Inventory
{

    #region 属性
    private int id;//唯一区分物品的ID
    private string name;//物品的名字
    private string image;//物品在图集中的名称
    private InventoryType inventoryType;//物品类型
    private EquipType equipType;//装备类型
    private int price;//物品价格
    private int startLevel;//装备星级
    private int quality;//装备品级
    private int damage;//装备伤害
    private int hp;//装备提供生命值
    private int power;//装备战斗力
    private InfoType infoType;//作用类型，作用在什么属性上
    private int applyValue;//作用值
    private string des;//物品描述
    #endregion
   
    #region get,set方法
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }

    public InventoryType InventoryType
    {
        get
        {
            return inventoryType;
        }

        set
        {
            inventoryType = value;
        }
    }

    public EquipType EquipType
    {
        get
        {
            return equipType;
        }

        set
        {
            equipType = value;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int StartLevel
    {
        get
        {
            return startLevel;
        }

        set
        {
            startLevel = value;
        }
    }

    public int Quality
    {
        get
        {
            return quality;
        }

        set
        {
            quality = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public InfoType InfoType
    {
        get
        {
            return infoType;
        }

        set
        {
            infoType = value;
        }
    }

    public int ApplyValue
    {
        get
        {
            return applyValue;
        }

        set
        {
            applyValue = value;
        }
    }

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }
    #endregion
}

using UnityEngine;
using System.Collections;

//定义委托用到的枚举
public enum InfoType
{
    Name,
    Portrait,
    Level,
    Gold,
    Diamond,
    Exp,
    Vit,
    Vigor,
    HP,
    Damage,
    Equip,
    All
}
//玩家的类型：男、女
public enum PlayerType
{
    male,
    female
}
public class PlayInfo : MonoBehaviour
{
    //单例模式
    public static PlayInfo _instance;

    #region 属性
    //玩家ID
    private string _name;
    //玩家头像
    private string _portrait;
    //玩家等级
    private int _level;
    //玩家经验
    private int _exp;
    //玩家体力
    private int _vit;
    //玩家精力
    private int _vigor;
    //玩家金币
    private int _gold;
    //玩家钻石
    private int _diamond;
    //玩家战斗力
    private int _fight;
    //玩家生命值
    private int _hp;
    //玩家伤害
    private int _damage;
    //玩家的类型
    private PlayerType _playerType;
    //玩家身上的装备信息，初始状态为没有装备
    private int _helmID=0;//头盔
    private int _clothID=0;//衣服
    private int _weaponID=0;//武器
    private int _shoesID=0;//鞋子
    private int _necklaceID=0;//项链
    private int _braceletID=0;//手镯
    private int _ringID=0;//戒指
    private int _wingsID=0;//翅膀
    #endregion

    #region get,set方法

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string Portrait
    {
        get
        {
            return _portrait;
        }

        set
        {
            _portrait = value;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }

    public int Vit
    {
        get
        {
            return _vit;
        }

        set
        {
            _vit = value;
        }
    }

    public int Vigor
    {
        get
        {
            return _vigor;
        }

        set
        {
            _vigor = value;
        }
    }

    public int Gold
    {
        get
        {
            return _gold;
        }

        set
        {
            _gold = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    public int Fight
    {
        get
        {
            return _fight;
        }

        set
        {
            _fight = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

    public int HelmID
    {
        get
        {
            return _helmID;
        }

        set
        {
            _helmID = value;
        }
    }

    public int ClothID
    {
        get
        {
            return _clothID;
        }

        set
        {
            _clothID = value;
        }
    }

    public int WeaponID
    {
        get
        {
            return _weaponID;
        }

        set
        {
            _weaponID = value;
        }
    }

    public int ShoesID
    {
        get
        {
            return _shoesID;
        }

        set
        {
            _shoesID = value;
        }
    }

    public int NecklaceID
    {
        get
        {
            return _necklaceID;
        }

        set
        {
            _necklaceID = value;
        }
    }

    public int BraceletID
    {
        get
        {
            return _braceletID;
        }

        set
        {
            _braceletID = value;
        }
    }

    public int RingID
    {
        get
        {
            return _ringID;
        }

        set
        {
            _ringID = value;
        }
    }

    public int WingsID
    {
        get
        {
            return _wingsID;
        }

        set
        {
            _wingsID = value;
        }
    }

    public PlayerType PlayerType
    {
        get
        {
            return _playerType;
        }

        set
        {
            _playerType = value;
        }
    }

    #endregion

    #region
    void Awake()
    {
        _instance = this;
    }
    #endregion

    void Start()
    {
        Init();
    }
    //初始化人物属性
    public void Init()
    {
        this.Name = "全都是泡馍";
        this.Portrait = "male";
        this.Level = 13;
        this.Gold = 666;
        this.Diamond = 666;
        this.Exp = 66;
        this.Vit = 50;
        this.Vigor = 33;
        this.Fight = 666;
        //给玩家赋予装备
        this.HelmID = 1001;
        this.ClothID = 1002;
        this.ShoesID = 1003;
        this.WeaponID = 1004;
        this.NecklaceID = 1005;
        this.BraceletID = 1006;
        this.RingID = 1007;
        this.WingsID = 1008;
        InitHPDamageAndFight();


        //初始化时所有属性都被更改
        OnPlayerInfoChanged(InfoType.All);
    }

    //定义一个初始化血量、伤害、战斗力的方法
    void InitHPDamageAndFight()
    {
        //根据公式计算出当前角色的血量、伤害、战斗力
        this.Hp = this.Level * 50;
        this.Damage = this.Level * 25;
        this.Fight = this.Hp + this.Damage;
        PutOnEquement(HelmID);
        PutOnEquement(ClothID);
        PutOnEquement(ShoesID);
        PutOnEquement(WeaponID);
        PutOnEquement(NecklaceID);
        PutOnEquement(BraceletID);
        PutOnEquement(RingID);
        PutOnEquement(WingsID);
    }

    //定义一个委托
    public delegate void OnPlayerInfoChangedEvent(InfoType type);
    //利用委托定义一个事件
    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;

    //体力精力计时器
    public float vitTimer=0;
    public float vigorTimer=0;

    #region 体力与精力的自动增长

    void Update()
    {
        //体力每分钟增加1，增加到100为止
        if (this.Vit < 100)
        {
            vitTimer += Time.deltaTime;
            if (vitTimer >= 60)
            {
                this.Vit += 1;
                vitTimer = 0;
                OnPlayerInfoChanged(InfoType.Vit);
            }
            else
            {
                //vitTimer = 0;
            }
        }
        //精力每分钟增肌1,50为止
        if (this.Vigor < 50)
        {
            vigorTimer += Time.deltaTime;
            if (vigorTimer >= 60)
            {
                this.Vigor += 1;
                vigorTimer = 0;
                OnPlayerInfoChanged(InfoType.Vigor);
            }
            else
            {
                //vigorTimer = 0;
            }
        }
    }
    #endregion

    public void ChangeName(string newname)
    {
        this.Name = newname;
        OnPlayerInfoChanged(InfoType.Name);
    }

    //定义穿上装备的方法
   void PutOnEquement(int id)
    {
        if (id==0)
        {
            return;//没有装备则返回
        }
        //根据装备ID取到在InventoryManager中定义的属性
        Inventory it = null;
        InventoryManager._instance.inventoryDic.TryGetValue(id,out it);
        //人物属相随着装备属性的变化而变化
        this.Hp += it.Hp;
        this.Damage += it.Damage;
        this.Fight += it.Power;
    }
    //定义脱下装备的放法
    void PutOffEquement(int id)
    {
        if (id == 0)
        {
            return;//没有装备则返回
        }
        //根据装备ID取到在InventoryManager中定义的属性
        Inventory it = null;
        InventoryManager._instance.inventoryDic.TryGetValue(id, out it);
        //人物属相随着装备属性的变化而变化
        this.Hp -= it.Hp;
        this.Damage -= it.Damage;
        this.Fight -= it.Power;
    }
}

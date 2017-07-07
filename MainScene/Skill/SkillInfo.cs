using UnityEngine;
using System.Collections;
//技能类型的枚举
public enum SkillType
{
    Basic,//基础攻击
    Skill//技能
}
//技能位置的枚举
public enum SkillPos
{
    Basic,
    One,
    Two,
    Three
}
public class SkillInfo : MonoBehaviour {
    #region 技能的属性
    //技能的ID
    private int _id;
    //技能的名字
    private string _name;
    //技能的图标
    private string _icon;
    //技能的类型
    private SkillType _skillType;
    //玩家的类型
    private PlayerType _playerType;
    //技能的位置
    private SkillPos _skillPos;
    //技能的冷却
    private int _coldTime;
    //技能的伤害
    private int _damage;
    //技能的等级
    private int _level;
    //技能描述
    private string _des;
    #endregion

    #region get,set方法
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

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

    public string Icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
        }
    }

    public SkillType SkillType
    {
        get
        {
            return _skillType;
        }

        set
        {
            _skillType = value;
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

    public SkillPos SkillPos
    {
        get
        {
            return _skillPos;
        }

        set
        {
            _skillPos = value;
        }
    }

    public int ColdTime
    {
        get
        {
            return _coldTime;
        }

        set
        {
            _coldTime = value;
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

    public string Des
    {
        get
        {
            return _des;
        }

        set
        {
            _des = value;
        }
    }
    #endregion
}

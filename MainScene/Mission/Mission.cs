using UnityEngine;
using System.Collections;
//任务类型
public enum MissionType
{
    Main,//主线任务
    Reward,//悬赏任务
    Daily//日常任务
}
//任务进度
public enum MissionPlan
{
    NotStart,//未接受
    Accept,//接受
    Complete,//完成
    Award//接受奖励

}
public class Mission : MonoBehaviour
{
    //设置任务属性
    private int id;//Id
    private MissionType missionType;//任务类型（Main,Reward，Daily）
    private string missionName;//名称
    private string image;//图标
    private string des;//任务描述
    private int gold;//获得的金币奖励
    private int diamond;//获得的钻石奖励
    private string npcTalk;//跟npc交谈的话语
    private int npcId;//Npc的id
    private int fbId;//副本id
    private MissionPlan missionPlan=MissionPlan.NotStart;//任务的状态

    //定义一个委托
    public delegate void OnMissionChangeEvent();
    //用委托生成一个事件
    public event OnMissionChangeEvent OnMissionChange;

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

    public MissionType MissionType
    {
        get
        {
            return missionType;
        }

        set
        {
            missionType = value;
        }
    }

    public string MissionName
    {
        get
        {
            return missionName;
        }

        set
        {
            missionName = value;
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

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold = value;
        }
    }

    public int Diamond
    {
        get
        {
            return diamond;
        }

        set
        {
            diamond = value;
        }
    }

    public string NpcTalk
    {
        get
        {
            return npcTalk;
        }

        set
        {
            npcTalk = value;
        }
    }

    public int NpcId
    {
        get
        {
            return npcId;
        }

        set
        {
            npcId = value;
        }
    }

    public int FbId
    {
        get
        {
            return fbId;
        }

        set
        {
            fbId = value;
        }
    }

    public MissionPlan MissionPlan
    {
        get
        {
            return missionPlan;
        }

        set
        {
            if (missionPlan!=value)
            {
                missionPlan = value;
                OnMissionChange();
            }
        }
    }
}

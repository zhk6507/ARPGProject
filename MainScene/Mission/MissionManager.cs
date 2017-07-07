using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {
    //接收任务清单TXT
    public TextAsset missionInfoText;
    //存储所有任务信息
    private ArrayList missionList = new ArrayList();
    //当前执行的任务
    private Mission currentMission;
    //获取玩家自动寻路的脚本
    public PlayerAutoMove playerAutoMove;

    //单例模式
    public static MissionManager _instance;

    void Awake()
    {
        
    }
    void Start()
    {
        //单例模式赋值
        _instance = this;
        IntiMission();
    }

    //从文本文档中初始化任务信息
    public void IntiMission()
    {
        //文本文档内容按行分隔
        string[] missionInfoArray = missionInfoText.ToString().Split('\n');
        //遍历每一行，再按照‘|’分隔
        foreach (string item in missionInfoArray)
        {
            string[] proArray = item.Split('|');
            Mission mission = new Mission();
            //获取任务ID
            mission.Id = int.Parse(proArray[0]);
            //判断任务类型
            switch (proArray[1])
            {
                case "Main":
                    mission.MissionType = MissionType.Main;
                    break;
                case "Reward":
                    mission.MissionType = MissionType.Reward;
                    break;
                case "Daily":
                    mission.MissionType = MissionType.Daily;
                    break;
            }
            //任务名称
            mission.MissionName = proArray[2];
            //任务图标
            mission.Image = proArray[3];
            //任务描述
            mission.Des= proArray[4];
            //任务金币获得
            mission.Gold= int.Parse(proArray[5]);
            //任务钻石获得
            mission.Diamond = int.Parse(proArray[6]);
            //与任务NPC的交谈
            mission.NpcTalk = proArray[7];
            //任务NPC的ID
            mission.NpcId = int.Parse(proArray[8]);
            //任务副本的ID
            mission.FbId = int.Parse(proArray[9]);
            //将这个任务添加到集合中
            missionList.Add(mission);
            
        }
    }

    //一个外部调用到missionList的方法，出于安全性考虑
    public ArrayList GetMissionList()
    {
        return missionList;
    }

    //执行某个任务
    public void OnExcuteMission(Mission mission)
    {
        currentMission = mission;
        if (mission.MissionPlan==MissionPlan.NotStart)
        {
            //任务状态是未开始，导航到NPC接受任务
            playerAutoMove.SetDestination(NPCManager._instance.GetNpcById(mission.NpcId).transform.position);
        }
        else if (mission.MissionPlan==MissionPlan.Accept)
        {
            //任务已经接受，导航到副本入口的位置
            playerAutoMove.SetDestination(NPCManager._instance.fbEnter.transform.position);
        }
    }

    public void AcceptMission()
    {
        currentMission.MissionPlan = MissionPlan.Accept;
        PlayerAutoMove._instance.SetDestination(NPCManager._instance.fbEnter.transform.position);
    }

    public void ArriveNpc()
    {
        if (currentMission.MissionPlan==MissionPlan.NotStart)
        {
            //currentMission.MissionPlan = MissionPlan.Accept;
            NPCDialogUI._instance.DialogShow(currentMission.Des);
        }
    }
}

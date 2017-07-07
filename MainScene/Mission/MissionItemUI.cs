using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionItemUI : MonoBehaviour {
    //得到任务列表控件上所有需要修改的组件
    //任务类型
    public Text missionType;
    //任务类型图片 黄蓝感叹号
    public Image missionTypeImage;
    //任务名称
    public Text missionName;
    //任务描述
    public Text missionDes;
    //奖励1图片
    public Image reward1Image;
    //奖励1数量
    public Text reward1Num;
    //奖励2图片
    public Image reward2Image;
    //奖励2数量
    public Text reward2Num;
    //战斗按钮
    public Button fightButton;
    //战斗按钮显示文本
    public Text fightButtonText;
    //领取奖励按钮
    public Button rewardButton;

     public Mission mission;

    //单例模式
    public static MissionItemUI _instance;

    void Start()
    {
        //单例模式赋值
        _instance = this;
    }

    //定义一个设置任务属性的方法
    public void SetMission(Mission mission)
    {
        this.mission = mission;
        //注册监听事件
        mission.OnMissionChange += this.OnMissionChange;
        UpdateShow();
    }

    //更新任务状态
    void UpdateShow()
    {
        //判断任务类型
        switch (mission.MissionType)
        {
            case MissionType.Main:
                missionType.text = "主线";
                break;
            case MissionType.Daily:
                missionType.text = "日常";
                break;
            case MissionType.Reward:
                missionType.text = "悬赏";
                break;
        }
        //根据主线支线任务不同显示不同感叹号图片
        missionTypeImage.overrideSprite = Resources.Load(mission.Image, typeof(Sprite)) as Sprite;
        //任务名称
        missionName.text = mission.MissionName;
        //任务描述
        missionDes.text = mission.Des;
        //判断有几个奖励
        if (mission.Gold > 0 && mission.Diamond > 0)//奖励金币与钻石
        {
            //赋值金币图片与数量
            reward1Image.overrideSprite = Resources.Load("金币", typeof(Sprite)) as Sprite;
            reward1Num.text = "X" + mission.Gold.ToString();
            //赋值钻石图片与数量
            reward2Image.overrideSprite = Resources.Load("钻石", typeof(Sprite)) as Sprite;
            reward2Num.text = "X" + mission.Diamond.ToString();
        }
        else if (mission.Gold > 0)//奖励金币
        {
            //赋值金币图片与数量
            reward1Image.overrideSprite = Resources.Load("金币", typeof(Sprite)) as Sprite;
            reward1Num.text = "X" + mission.Gold.ToString();
            //取消显示钻石奖励
            reward2Image.gameObject.SetActive(false);
            reward2Num.gameObject.SetActive(false);
        }
        else if (mission.Diamond > 0)
        {
            //赋值钻石图片与数量
            reward2Image.overrideSprite = Resources.Load("钻石", typeof(Sprite)) as Sprite;
            reward2Num.text = "X" + mission.Diamond.ToString();
            //取消显示金币奖励
            reward1Image.gameObject.SetActive(false);
            reward1Num.gameObject.SetActive(false);
        }

        switch (mission.MissionPlan)
        {
            case MissionPlan.NotStart:
                //任务还未开始，隐藏领取奖励按钮
                rewardButton.gameObject.SetActive(false);
                fightButtonText.text = "下一步";
                break;
            case MissionPlan.Accept:
                //任务接受，点击战斗按钮
                rewardButton.gameObject.SetActive(false);
                fightButtonText.text = "战斗";
                break;
            case MissionPlan.Complete:
                //任务完成，接受奖励
                fightButton.gameObject.SetActive(false);
                break;
        }
    }

    //战斗按钮的点击
    public void OnFightButtonClick()
    {
        MissionManager._instance.OnExcuteMission(mission);
        MissionPanelShow._instance.missionAnimation.DOPlayBackwards();
        MissionPanelShow._instance.isShow = false;
    }

    //获取奖励按钮的点击

    //任务状态发生改变的事件
    void OnMissionChange()
    {
        UpdateShow();
    }
}

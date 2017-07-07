using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class NPCDialogUI : MonoBehaviour {
    //获得任务NPC对话框的动画
    public DOTweenAnimation npcDialogAnimation;
    //获得任务对话框的内容
    public Text missionDes;
    //单例模式
    public static NPCDialogUI _instance;
	// Use this for initialization
	void Start () {
        //单例模式赋值
        _instance = this;

    }		

    //对话框显示的方法
    public void DialogShow(string des)
    {
        npcDialogAnimation.DOPlayForward();
        missionDes.text = des;
    }

    //接受按钮点击 接受任务
    public void AcceptButtonOnClick()
    {
        npcDialogAnimation.DOPlayBackwards();
        MissionManager._instance.AcceptMission();
    }
}

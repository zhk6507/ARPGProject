using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class MissionPanelShow : MonoBehaviour {
    public DOTweenAnimation missionAnimation;
    public Button closeButton;
    public Button missionButton;
    public bool isShow = false;
    //单例模式
    public static MissionPanelShow _instance;
    void Start()
    {
        //单例模式赋值
        _instance = this;
        //按钮的监听
        closeButton.onClick.AddListener(delegate {
            missionAnimation.DOPlayBackwards();
            isShow = false;
        });

        missionButton.onClick.AddListener(delegate {
            if (isShow)
            {
                missionAnimation.DOPlayBackwards();
                isShow = false;
            }
            else
            {
                missionAnimation.DOPlayForward();
                isShow = true;
            }
        });
    }
}

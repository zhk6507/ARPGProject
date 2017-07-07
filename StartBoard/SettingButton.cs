using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SettingButton : MonoBehaviour {
    //得到设置界面的动画
    public DOTweenAnimation settingWindowAnimation;

    //点击设置按钮
    public void SettingButtonOnClick()
    {
        //显示设置界面
        settingWindowAnimation.DOPlayForward();
    }

    //点击关闭按钮
    public void CloseButtonOnClick()
    {
        //隐藏设置界面
        settingWindowAnimation.DOPlayBackwards();
    }
}

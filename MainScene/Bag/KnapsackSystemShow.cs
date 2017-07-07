using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class KnapsackSystemShow : MonoBehaviour {
    //得到背包的动画
    public DOTweenAnimation knapsackAnimation;
    //背包的显示状态
    private bool isShow = false;
    //下方背包按钮
    public Button bagButton;
    //背包关闭按钮
    public Button bagCloseButton;
    void Start()
    {
        //背包动画赋值
        //knapsackAnimation = this.GetComponent<DOTweenAnimation>();
    }

    public void BagButtonOnClick()
    {
        //判断isShow状态
        if (isShow)
        {
            //动画回放
            knapsackAnimation.DOPlayBackwards();
            //改变isShow状态
            isShow = false;
        }
        else
        {
            //动画播放
            knapsackAnimation.DOPlayForward();
            //改变isShow状态
            isShow = true;
        }
    }

    //装备关闭按钮
    public void BagCloseOnClick()
    {
        //动画回放
        knapsackAnimation.DOPlayBackwards();
        isShow = false;
    }
}

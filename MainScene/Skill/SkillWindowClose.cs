using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SkillWindowClose : MonoBehaviour {
    public DOTweenAnimation skillWindowAnimation;
    private bool isShow=false;
    public void SkillWindowShow()
    {
        if (isShow)
        {
            skillWindowAnimation.DOPlayBackwards();
            isShow = false;
        }
        else
        {
            skillWindowAnimation.DOPlayForward();
            isShow = true;
        }
    }
	
}

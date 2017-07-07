using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MapCloseButtonOnClick : MonoBehaviour {
    public DOTweenAnimation windowAnimation;
	
    public void WindowCloseButtonOnClick()
    {       
            windowAnimation.DOPlayBackwards();     
    }

    public void WindowShowButtonOnClick()
    {
        windowAnimation.DOPlayForward();
    }
}

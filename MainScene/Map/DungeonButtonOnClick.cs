using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class DungeonButtonOnClick : MonoBehaviour {
    public Text dungeonName;
    public Text dungeonDes;
    public DOTweenAnimation dungeonWindowAnimation;
    public void ButtonOnClick()
    {
        dungeonName.text=this.GetComponent<DungeonMessage>().dungeonName;
        dungeonDes.text = this.GetComponent<DungeonMessage>().dungeonDes;
        dungeonWindowAnimation.DOPlayForward();
    }
}

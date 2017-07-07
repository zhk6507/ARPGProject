using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButtonOnClick : MonoBehaviour {
    //得到技能的Mask
    public Image skillMask;
    //技能冷却时间
    public float coldTime;
    //计时器
    private float coldTimer;
    //得到技能按钮
    public Button skillButton;


    void Update()
    {
        if (coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            skillMask.fillAmount = coldTimer / coldTime;
        }
        else
        {
            coldTimer = 0;
            skillButton.enabled = true;
        }
    }   

    //技能按钮的点击
    public void SkillButtonsOnClick()
    {
        coldTimer = coldTime;
        skillButton.enabled = false;
    }
}

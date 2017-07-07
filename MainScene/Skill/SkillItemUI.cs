using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillItemUI : MonoBehaviour {
    //根据技能位置不同区别技能
    public SkillPos skillpos;
    
    private SkillInfo skillInfo;
    public Image skillImage;
    public Text skillName;
    public Text skillDes;
    public Text skillLevel;
    public Text skillDamage;
    void Start()
    {
        skillInfo = SkillManager._instance.GetSkillByPos(skillpos);
        skillImage.overrideSprite = Resources.Load(skillInfo.Icon, typeof(Sprite)) as Sprite;
        skillName.text = skillInfo.Name;
        skillDes.text = skillInfo.Des;
        skillDamage.text = skillInfo.Damage.ToString();
        skillLevel.text = skillInfo.Level.ToString();

    }
}

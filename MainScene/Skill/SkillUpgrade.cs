using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour {
    public Text skillDamage;
    public Text skillLevel;
    public void SkillUpgradeButtonOnClick()
    {
        if (int.Parse(skillLevel.text.ToString()) < PlayInfo._instance.Level)
        {
            skillDamage.text = (int.Parse(skillDamage.text) + 10 + 2 * PlayInfo._instance.Level).ToString();
            skillLevel.text = (int.Parse(skillLevel.text)+1).ToString();
        }
    }
}

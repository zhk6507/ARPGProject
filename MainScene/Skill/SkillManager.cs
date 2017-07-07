using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour
{
    //技能信息Text的接收
    public TextAsset skillInfoText;
    //存储技能信息的ArrayList
    public ArrayList skillList = new ArrayList();
    //单例模式
    public static SkillManager _instance;

    void Awake()
    {
        //单例模式赋值
        _instance = this;
        //初始化技能信息
        InitSkillInfo();
    }
    void Start()
    {



    }

    //初始化技能信息
    void InitSkillInfo()
    {
        //按行将文内容分割
        string[] skillArray = skillInfoText.ToString().Split('\n');
        //遍历数组
        foreach (string item in skillArray)
        {
            //每一行再按照‘，’进行分割，得到技能的每一个属性
            string[] proArray = item.Split('|');
            //新建一个Skill保存属性
            SkillInfo skill = new SkillInfo();
            //技能ID
            skill.Id = int.Parse(proArray[0]);
            //技能名称
            skill.Name = proArray[1];
            //技能图标
            skill.Icon = proArray[2];
            //玩家角色类型
            switch (proArray[3])
            {
                case "Male":
                    skill.PlayerType = PlayerType.male;
                    break;
                case "Female":
                    skill.PlayerType = PlayerType.female;
                    break;
            }
            //技能类型
            switch (proArray[4])
            {
                case "Basic":
                    skill.SkillType = SkillType.Basic;
                    break;
                case "Skill":
                    skill.SkillType = SkillType.Skill;
                    break;
            }
            //技能位置
            switch (proArray[5])
            {
                case "Basic":
                    skill.SkillPos = SkillPos.Basic;
                    break;
                case "One":
                    skill.SkillPos = SkillPos.One;
                    break;
                case "Two":
                    skill.SkillPos = SkillPos.Two;
                    break;
                case "Three":
                    skill.SkillPos = SkillPos.Three;
                    break;
            }
            //技能冷却
            skill.ColdTime = int.Parse(proArray[6]);
            //技能伤害
            skill.Damage = int.Parse(proArray[7]);
            //技能描述
            skill.Des = proArray[8];
            //技能等级
            skill.Level = 1;
            //读取完成，保存
            skillList.Add(skill);
        }
    }

    //通过技能位置获取技能
    public SkillInfo GetSkillByPos(SkillPos pos)
    {
        PlayInfo info = PlayInfo._instance;
        foreach (SkillInfo skill in skillList)
        {
            if (info.PlayerType == skill.PlayerType && skill.SkillPos == pos)
            {
                return skill;
            }
        }
        return null;
    }
}
   

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EquipupGrade : MonoBehaviour {
    //得到装备相应的ID
    private string id;
    
    //得到装备属性面板星级和战斗力属性
    public Text equipPower;
    public Text equipLevel;
    public Text equipId;

    public void EquipmentGradeOnClick()
    {
        //把当前装备的ID传入id中
         id =equipId.text ;
         int n=Convert.ToInt32(id);
        //得到字典集合中相应的装备信息
        Inventory it = InventoryManager._instance.inventoryDic[n];
        
        //装备属性提升
        //星级提高
        it.StartLevel += 1;
        equipLevel.text = it.StartLevel.ToString();
        //战斗力提高
        it.Power += it.StartLevel*25+100;
        equipPower.text = it.Power.ToString();

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowEquipInfo : MonoBehaviour
{
    //装备面板相应的装备ID
    public int i;
    //得到装备属性面板相应的属性
    public Text equipName;
    public Image equipImage;
    public Text equipQuality;
    public Text equipHp;
    public Text equipDamage;
    public Text equipPower;
    public Text equipInfo;
    public Text equipLevel;
    public Text equipId;
    //得到装备面板
    public GameObject infoWindow;
    //单例模式
    public static ShowEquipInfo _instance;

    void Start()
    {
        //单例模式注册
        _instance = this;

    }
    public void EquipOnClick()
    {
        Inventory it = InventoryManager._instance.inventoryDic[i];
        //监听点击事件，按下的时候显示装备信息框       
        Show(it);
    }

    public void Show(Inventory it)
    {
        infoWindow.SetActive(true);
        //将属性进行相应的修改
        equipName.text = it.Name;
        equipImage.overrideSprite = Resources.Load(it.Image, typeof(Sprite)) as Sprite;
        equipQuality.text = it.Quality.ToString(); ;
        equipHp.text = it.Hp.ToString();
        equipDamage.text = it.Damage.ToString();
        equipPower.text = "战斗力：" + it.Power.ToString();
        equipInfo.text = it.Des;
        equipLevel.text = it.StartLevel.ToString(); 
        equipId.text=it.Id.ToString();
    }
}

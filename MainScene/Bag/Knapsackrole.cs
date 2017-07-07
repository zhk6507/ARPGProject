using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Knapsackrole : MonoBehaviour {
    //得到背包中人物属性面板上的属性
    private RolesEquip helmEquip;
    private RolesEquip closeEquip;
    private RolesEquip weaponEquip;
    private RolesEquip shoesEquip;
    private RolesEquip necklaceEquip;
    private RolesEquip braceleEquip;
    private RolesEquip ringEquip;
    private RolesEquip wingsEquip;
    private Text hp;
    private Text damage;
    private Text exp;
    public Slider expSlider;

    void Awake()
    {
        //给属性赋值
        helmEquip = GameObject.Find("HelmImage").GetComponent<RolesEquip>();
        closeEquip = GameObject.Find("CloseImage").GetComponent<RolesEquip>();
        weaponEquip = GameObject.Find("WeaponImage").GetComponent<RolesEquip>();
        shoesEquip = GameObject.Find("ShoesImage").GetComponent<RolesEquip>();
        necklaceEquip = GameObject.Find("NecklaceImage").GetComponent<RolesEquip>();
        braceleEquip = GameObject.Find("BraceleImage").GetComponent<RolesEquip>();
        ringEquip = GameObject.Find("RingImage").GetComponent<RolesEquip>();
        wingsEquip = GameObject.Find("WingsImage").GetComponent<RolesEquip>();
        hp = GameObject.Find("HPText").GetComponent<Text>();
        damage = GameObject.Find("DamageText").GetComponent<Text>();
        exp = GameObject.Find("ExpText").GetComponent<Text>();
        //expSlider = GameObject.Find("ExpSlider").GetComponent<Slider>();
        
    }
    void Start()
    {
        //将事件进项注册
        PlayInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }
    //将事件进行注销
    void OnDestroy()
    {
        PlayInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }
    //当人物属性面板发生变化时，调用这个方法
    void OnPlayerInfoChanged(InfoType type)
    {
        if (type==InfoType.All||type==InfoType.HP||type==InfoType.Damage||type==InfoType.Equip)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        //setId方法暂不能实现，直接将图片从Unity中进行修改
        PlayInfo info = PlayInfo._instance;
        //helmEquip.SetId(info.HelmID);
        //closeEquip.SetId(info.ClothID);
        //shoesEquip.SetId(info.ShoesID);
        //weaponEquip.SetId(info.ShoesID);
        //necklaceEquip.SetId(info.NecklaceID);
        //braceleEquip.SetId(info.BraceletID);
        //ringEquip.SetId(info.RingID);
        //wingsEquip.SetId(info.WingsID);

        hp.text = info.Hp.ToString();
        damage.text = info.Damage.ToString();
        expSlider.value = (float)info.Exp / GameController.GetNeedExpByLevel(info.Level+1);
        exp.text = info.Exp+"/"+ GameController.GetNeedExpByLevel(info.Level + 1);
    }
}

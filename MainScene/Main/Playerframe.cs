using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Playerframe : MonoBehaviour {
    //得到玩家头像框的所有属性
    private Image playerHead;
    private Text playerName;
    private Slider vitSlider;
    private Slider vigorSlider;
    private Text vitText;
    private Text vigorText;
    private Button vitPlusButton;
    private Button vigorPluseButton;
    private Text playerLevel;
    public Button showPlayerStats;
    void Awake()
    {
        playerHead = GameObject.Find("PlayerHead").GetComponent<Image>();
        playerName = GameObject.Find("Playername").GetComponent<Text>();
        vitSlider = GameObject.Find("VitSlider").GetComponent<Slider>();
        vigorSlider = GameObject.Find("VigorSlider").GetComponent<Slider>();
        vitText = GameObject.Find("Vittext").GetComponent<Text>();
        vigorText = GameObject.Find("Vigortext").GetComponent<Text>();
        vitPlusButton = GameObject.Find("VitButtonPlus").GetComponent<Button>();
        vigorPluseButton = GameObject.Find("VigorButtonPlus").GetComponent<Button>();
        playerLevel = GameObject.Find("Playerlevel").GetComponent<Text>();
        //showPlayerStats = GameObject.Find("PlayerHead").GetComponent<Button>();
    }

    void Start() {
        //将事件进行注册
        PlayInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
        //监听头像按钮点击事件
        
        showPlayerStats.onClick.AddListener(delegate
        {
            HeadButtonOnClick();
        });
    }

    //将事件进行注销
    void Destroy()
    {
        PlayInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    //当主角信息属性发生变化时，会触发这个方法
    void OnPlayerInfoChanged(InfoType type)
    {
        if (type==InfoType.Portrait||type==InfoType.Level||type==InfoType.Name||type==InfoType.Vit||type==InfoType.Vigor||type==InfoType.All)
        {
            UptadeShow();
        }
    }

    //更新属性
    void UptadeShow()
    {
        PlayInfo info = PlayInfo._instance;
        playerHead.name = info.Portrait;
        playerLevel.text = "LV."+info.Level.ToString();
        playerName.text = info.Name;
        vigorText.text = info.Vigor.ToString() + "/100";
        vitText.text = info.Vit.ToString() + "/100";
        vitSlider.value = info.Vit / 100f;
        vigorSlider.value = info.Vigor / 100f;
    }

   void HeadButtonOnClick()
    {
        Charavtersatas._instance.ShowPanel();
    }
}

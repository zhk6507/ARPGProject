using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Charavtersatas : MonoBehaviour {
    //获得人物属性面板所有属性
    
    private Text playerName;
    private Text Combateeffectiveness;
    public Button changeName;
    private Slider expSlider;
    private Text expText;
    private Text goldText;
    private Text diamondText;
    private Text vitText;
    private Text vitRecoverTime;
    private Text vitAllRecoverTime;
    private Text vigorText;
    private Text vigorRecoverTime;
    private Text vigorAllrecoverTime;
    public Button closeButton;
    private DOTweenAnimation characterStatsAnimation;
    public GameObject changeNamePanel;
    public Button changeNameConfirm;
    public Button changeNameQuit;
    public Text changeNameInput;
    //定义一个单例模式
    public static Charavtersatas _instance;
    void Awake()
    {
        //给单例模式赋值
        _instance = this;
        playerName = GameObject.Find("PlayerID").GetComponent<Text>();
        Combateeffectiveness = GameObject.Find("Combateffectivenessnum").GetComponent<Text>();       
        expSlider = GameObject.Find("ExpSlider").GetComponent<Slider>();
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        goldText = GameObject.Find("Goldnum").GetComponent<Text>();
        diamondText = GameObject.Find("Diamondnum").GetComponent<Text>();
        vitText = GameObject.Find("Vitnum").GetComponent<Text>();
        vitRecoverTime = GameObject.Find("Vitrecovertime").GetComponent<Text>();
        vitAllRecoverTime = GameObject.Find("Vitallrecovertime").GetComponent<Text>();
        vigorText = GameObject.Find("Vigornum").GetComponent<Text>();
        vigorRecoverTime = GameObject.Find("Vigrecovertime").GetComponent<Text>();
        vigorAllrecoverTime = GameObject.Find("Vigorallrecovertime").GetComponent<Text>();
        characterStatsAnimation = this.GetComponent<DOTweenAnimation>();      
    }

    void Start()
    {
        //改名面板一开始隐藏
        changeNamePanel.SetActive(false);
        //注册属性改变的方法
        PlayInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
        //关闭人物属性面板
        closeButton.onClick.AddListener(delegate {
            characterStatsAnimation.DOPlayBackwards();
        });
        //点击改名按钮
        changeName.onClick.AddListener(delegate {
            changeNamePanel.SetActive(true);
        });
        //确认改名
        changeNameConfirm.onClick.AddListener(delegate {
            PlayInfo._instance.ChangeName(changeNameInput.text);
            changeNamePanel.SetActive(false);
        });
        //取消改名
        changeNameQuit.onClick.AddListener(delegate {
            changeNamePanel.SetActive(false);
        });
    }

    void Update()
    {
        //每一帧都刷新体力和精力的恢复
        UpdateVitandVigor();
    }

    //注销
    void Destroy()
    {
        PlayInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    //当玩家属性面板内属性变化时，调用这个方法
    void OnPlayerInfoChanged(InfoType type)
    {
        UpdateShow();
    }
    
    //更新属性面板
    void UpdateShow()
    {
        PlayInfo info = PlayInfo._instance;
        playerName.text = info.Name;
        Combateeffectiveness.text = info.Fight.ToString();
        int needExp = GameController.GetNeedExpByLevel(info.Level);
        expText.text = info.Exp.ToString()+"/"+needExp.ToString();
        expSlider.value = (float)info.Exp / needExp;
        goldText.text = info.Gold.ToString();
        diamondText.text = info.Diamond.ToString();
        vigorText.text = info.Vigor.ToString()+"/100";
        vitText.text=info.Vit.ToString() + "/100";
        //更新体力和历练的显示
        UpdateVitandVigor();
    }

    //更新体力精力恢复时间
    void UpdateVitandVigor()
    {
        PlayInfo info = PlayInfo._instance;
        //体力恢复
        if (info.Vit>=100)
        {
            vitRecoverTime.text = "00:00:00";
            vitAllRecoverTime.text = "00:00:00";
        }
        else
        {
            //下一体力恢复
            vitRecoverTime.text = ((int)(60 - info.vitTimer)).ToString();
            //全部体力恢复
            int restVit = 100 - info.Vit;//缺少的体力数
            int sec = restVit * 60;//恢复所有体力需要的秒数
            int minshow = sec / 60;//显示的分钟
            int sceShow = sec % 60;//显示的分钟数
            vitAllRecoverTime.text = minshow + "分钟";
        }
        //精力恢复
        if (info.Vigor >= 100)
        {
            vigorRecoverTime.text = "00:00:00";
            vigorAllrecoverTime.text = "00:00:00";
        }
        else
        {
            //下一体力恢复
            vigorRecoverTime.text = ((int)(60 - info.vigorTimer)).ToString();
            //全部体力恢复
            int restVigor = 100 - info.Vigor;//缺少的体力数
            int sec = restVigor * 60;//恢复所有体力需要的分钟数
            int minshow = sec / 60;//显示的小时
            int sceShow = sec % 60;//显示的分钟数
            vigorAllrecoverTime.text = minshow + "分钟";
        }
    }
    //显示人物属性面板的动画
    public void ShowPanel()
    {
        characterStatsAnimation.DOPlayForward();
    }
}

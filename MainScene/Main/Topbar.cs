using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Topbar : MonoBehaviour {

    private Text goldNums;
    private Button goldPlusButton;
    private Text diamondNums;
    private Button diamondPlusButton;

    void Awake()
    {
        goldNums = GameObject.Find("Goldnums").GetComponent<Text>();
        goldPlusButton = GameObject.Find("GoldButtonPlus").GetComponent<Button>();
        diamondNums = GameObject.Find("Diamondnums").GetComponent<Text>();
        diamondPlusButton = GameObject.Find("DiamondButtonPlus").GetComponent<Button>();
       
    }

    void Start()
    {
        //将方法进行注册
        PlayInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    //注销
    void OnDestroy()
    {
        PlayInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    //当钻石和金币数发生变化时，会触发这个方法
    void OnPlayerInfoChanged(InfoType type)
    {
        if (type==InfoType.All||type==InfoType.Diamond||type==InfoType.Gold)
        {
            UpdateShow();
        }
    }

    //修改金币和钻石的数量
    void UpdateShow()
    {
        PlayInfo info = PlayInfo._instance;
        goldNums.text = info.Gold.ToString();
        diamondNums.text = info.Diamond.ToString();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpDruhUse : MonoBehaviour {
    //获得物品信息面板的属性
    public Text drugName;
    public Text playerHp;
    //public Text drugNum;
    public Text message;

    //使用按钮的点击
    public void DrugUseOnClick()
    {
        
        //判断所选的物品
        if (drugName.text=="小型生命药剂")
        {
            if (InventoryInBagShow.num!=0)
            {
                int hp = int.Parse(playerHp.text) + 500;
                playerHp.text = hp.ToString();
                InventoryInBagShow.num--;                
                Debug.Log(InventoryInBagShow.num);
            }
            else
            {
                StartCoroutine(ShowMessage("你没有这个药剂了"));
            }
            
        }
        if (drugName.text == "大型生命药剂")
        {
            if (InventoryInBagShow.num != 0)
            {
                int hp = int.Parse(playerHp.text) + 1500;
                playerHp.text = hp.ToString();
                InventoryInBagShow.num--;                
                Debug.Log(InventoryInBagShow.num);
            }
            else
            {
                StartCoroutine(ShowMessage("你没有这个药剂了"));
            }
        }
        if (drugName.text == "小型法力药剂")
        {
            StartCoroutine(ShowMessage("你没有法力值"));
        }
        if (drugName.text == "大型法力药剂")
        {
            StartCoroutine(ShowMessage("你没有法力值！！"));
        }
        if (drugName.text == "黄金宝箱")
        {
             StartCoroutine(ShowMessage("这是一个假的宝箱。"));
        }
    }

    //展示提示信息
    IEnumerator ShowMessage(string mes)
    {
        message.gameObject.SetActive(true);
        message.text = mes;
        yield return new WaitForSeconds(0.5f);
        message.gameObject.SetActive(false);
    }
}

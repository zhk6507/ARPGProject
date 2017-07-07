using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipShow : MonoBehaviour {

    //得到装备属性面板
    public GameObject closeEquipWindow;

    public void CloseEquipWindowClose()
    {
        closeEquipWindow.SetActive(false);
    }
}

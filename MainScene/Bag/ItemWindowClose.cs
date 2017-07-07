using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemInfoWindowClose : MonoBehaviour {

    //取得窗口
    public GameObject itemInfoWindow;

    public void CloseItemWindowOnClick()
    {
        itemInfoWindow.SetActive(false);
    }
}

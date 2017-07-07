using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RolesEquip : MonoBehaviour {

    private Image _image;
    private Image Image
    {
        get
        {
            if (_image==null)
            {
                _image = this.GetComponent<Image>();
            }
            return _image;
        }
    }

    //错误，无法找到对应图片
    //public void SetId(int id)
    //{
    //    Inventory inventory = null;
    //    bool isHave = InventoryManager._instance.inventoryDic.TryGetValue(id,out inventory);
    //    if (isHave)
    //    {
    //        NGUI可以用Image.spriteName找到对应资源而UGUI没找到类似方法。
    //        Image = inventory.Image;
    //    }
    //}
}

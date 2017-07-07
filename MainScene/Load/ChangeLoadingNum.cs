using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeLoadingNum : MonoBehaviour {

    public Text loadNum;
    public Slider loadSlider;

    void Update()
    {
        loadNum.text = (loadSlider.value * 100).ToString() + "%";
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Voicebgm : MonoBehaviour {
    //得到调整音量大小的Slider
    public Slider voiceSlider;
    //得到BGM
    public AudioSource bgm;
    
    void Update()
    {
        //BGM音量大小随Slider值改变
        bgm.volume = voiceSlider.value;
    }

}

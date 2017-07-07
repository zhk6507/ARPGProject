using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneLoading : MonoBehaviour
{
    //得到Loading界面
    public GameObject loadScene;
    //定义一个接收加载状态的值
    private AsyncOperation ao;
    //获取进度条
    public Slider loadSlider;
    private GameObject maleModel;
    private GameObject femaleModel;
    void Start()
    {
        //开始时隐藏loading界面
        loadScene.SetActive(false);

    }

    void Update()
    {
        if (ao != null)
        {
            loadSlider.value = ao.progress;
            //loadSlider.value = 0.5f;
        }

    }

    //定义一个显示Loading界面的方法
    public void Show()
    {
        //显示加载界面
        loadScene.SetActive(true);   
    }

    IEnumerator LoadScene()
    {
        ao = SceneManager.LoadSceneAsync("MainScene");
        yield return ao;
    }

    public void OnButtonClick()
    {
        Show();
        StartCoroutine(LoadScene());
        maleModel = GameObject.Find("male_showselect(Clone)");
        femaleModel = GameObject.Find("female_showselect(Clone)");
        if (maleModel!=null)
        {
            maleModel.SetActive(false);
        }
        else
        {
            femaleModel.SetActive(false);
        }
        
    }
}

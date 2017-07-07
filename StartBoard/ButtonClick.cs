using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    //单例模式
    //public static ButtonClick _instance;

    //获得开始界面注册界面和服务器界面动画
    public DOTweenAnimation startAnimation;
    public DOTweenAnimation loginAnimation;
    public DOTweenAnimation serverAnimation;
    //定义两个静态变量存储用户输入的用户名和密码，等待验证
    public static string username;
    public static string password;
    //获得输入的用户名和密码
    public InputField usernameLogin;
    public InputField passwordLogin;
    //开始界面显示的用户名
    public Text usernameStart;

    //获得选择服务器最上方的服务器按钮文本
    public Text serverSelect;
    //获得开始界面服务器按钮文本
    public Text serverSelectStart;
    //获得被选择的服务器
    public Text server;
    //获得注册界面
    public DOTweenAnimation registerAnimation;

    //获得注册界面的用户名和密码
    public InputField usernameRegister;
    public InputField passwordRegister;

    //获得选择角色界面动画
    public DOTweenAnimation characterChooseAnimation;
    //获得角色创建界面动画
    public DOTweenAnimation characterShowAnimation;
    //给开始界面另一种LocalMove动画
    public Transform startPanel;

    //得到男性角色模型
    public Transform maleModle;
    //得到女性角色模型
    public Transform femaleModle;
    //得到创建角色界面文本输入框
    public InputField characterName;
    //得到更换角色界面角色信息文本
    public Text characterMessage;
    
    //得到更换角色界面应该创建模型的位置
    public Transform creatModelPlace;
    //在角色选择界面创建模型
    public  static int flag;
    public GameObject male;
    public GameObject female;

    //获得已经生成的角色
    private static GameObject createdModle;
    //void Awake()
    //{
    //    _instance = this;
    //}
        

    //点击开始按钮
    public void OnStartClick()
    {
        startPanel.DOLocalMoveX(650f,0.3f);
        StartCoroutine(HideUser(startPanel.gameObject));
        characterChooseAnimation.gameObject.SetActive(true);
        characterChooseAnimation.DOPlayForward();
    }

    //点击选择服务器按钮
    public void OnServerClick()
    {
        //隐藏开始界面
        startAnimation.DOPlayForward();
        StartCoroutine(HideUser(startAnimation.gameObject));
        //显示服务器面板
        serverAnimation.gameObject.SetActive(true);
        serverAnimation.DOPlayForward();

        //初始化服务器
        IntiServerList();
    }

    //初始化服务器
    public void IntiServerList()
    {
        //ToDo
    }

    //点击用户名按钮
    public void OnUserClick()
    {
        //播放动画并显隐面板
        startAnimation.DOPlayForward();
        StartCoroutine(HideUser(startAnimation.gameObject));
        loginAnimation.gameObject.SetActive(true);
        loginAnimation.DOPlayForward();
    }

    //隐藏面板
    IEnumerator HideUser(GameObject go)
    {
        yield return new WaitForSeconds(0.4f);
        go.SetActive(false);

    }

    public void OnLoginClick()
    {
        //得到用户名和变量并存储起来
        username = usernameLogin.text;
        password = passwordLogin.text;

        //点击登录按钮返回开始界面
        loginAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(loginAnimation.gameObject));
        startAnimation.gameObject.SetActive(true);
        startAnimation.DOPlayBackwards();
        usernameStart.text = username;
    }

    public void OnCloseClickLogin()
    {
        //返回开始界面
        loginAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(loginAnimation.gameObject));
        startAnimation.gameObject.SetActive(true);
        startAnimation.DOPlayBackwards();

    }

    public void OnRegisterClick()
    {
        //隐藏Login界面
        loginAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(loginAnimation.gameObject));
        //显示注册界面
        registerAnimation.gameObject.SetActive(true);
        registerAnimation.DOPlayForward();
    }

    public void OnRegisterCancelClick()
    {
        //隐藏注册面板。返回登陆面板
        registerAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(registerAnimation.gameObject));
        loginAnimation.gameObject.SetActive(true);
        loginAnimation.DOPlayForward();
    }

    public void OnRegisterCloserClick()
    {
        OnRegisterCancelClick();
    }

    public void OnRegisterLoginClick()
    {
        //保存用户名密码
        username = usernameRegister.text;
        password = passwordRegister.text;
        //隐藏注册界面
        registerAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(registerAnimation.gameObject));
        //返回开始界面
        startAnimation.gameObject.SetActive(true);
        startAnimation.DOPlayBackwards();

        usernameStart.text = username;
    }

     public void OnServerChoose()
    {
        //改变顶部和开始界面服务器选择
        serverSelect.text = server.text;
        serverSelectStart.text= server.text;
        //隐藏服务器选择界面
        serverAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(serverAnimation.gameObject));
        //显示开始界面
        startAnimation.gameObject.SetActive(true);
        startAnimation.DOPlayBackwards();
    }

    //点击男性选择按钮
    public void OnCharacterMaleClick()
    {
        //放大男性，女性恢复正常
        maleModle.DOScale(110f,0.3f);
        femaleModle.DOScale(140f,0.3f);
        flag = 1;
        Debug.Log(flag);
    }
    //点击选择女性按钮
    public void OnCharacterFemaleClick()
    {
        //放大女性，男性恢复正常
        femaleModle.DOScale(160f,0.3f);
        maleModle.DOScale(90f,0.3f);
        flag = 2;
        Debug.Log(flag);
    }
    //点击更换角色按钮
    public void OnChangeCharacterClick()
    {
        //隐藏角色选择界面，显示创建角色界面
        characterChooseAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(characterChooseAnimation.gameObject));
        characterShowAnimation.gameObject.SetActive(true);
        characterShowAnimation.DOPlayForward();
        if (createdModle!=null)
        {
            GameObject.Destroy(createdModle);
        }
    }
    //角色创建界面退出
    public void OnCharacterShowQuit()
    {
        //隐藏创建角色界面，显示角色选择界面
        characterChooseAnimation.gameObject.SetActive(true);
        characterChooseAnimation.DOPlayForward();
        characterShowAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(characterShowAnimation.gameObject));
    }

    //点击创建角色确定按钮事件
    public void OnShowCharacterConfirmClick()
    {
        //更改角色选择界面角色信息
        characterMessage.text = characterName.text;
        //生成角色模型
        
        if (flag==2)
        {
            createdModle= Instantiate(female) as GameObject;
            //go.transform.position = new Vector3(3f, -108f, -59f);
            Debug.Log("生成了女性角色");
            createdModle.transform.DOScale(26f,0);
            createdModle.transform.position = new Vector3(417.1f, 383.9f, 265.4f);
        }
        else if(flag==1)
        {
            createdModle = Instantiate(male) as GameObject;
            //go.transform.position = new Vector3(3f, -108f, -59f);
            Debug.Log("生成了男性角色");
            createdModle.transform.DOScale(15f, 0);
            createdModle.transform.position = new Vector3(417.1f, 383.9f, 265.4f);
        }
        //隐藏角色创建界面
        characterShowAnimation.DOPlayBackwards();
        StartCoroutine(HideUser(characterShowAnimation.gameObject));
        //显示角色选择界面
        characterChooseAnimation.gameObject.SetActive(true);
        characterChooseAnimation.DOPlayForward();   
    }
}

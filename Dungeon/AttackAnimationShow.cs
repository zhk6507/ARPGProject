using UnityEngine;
using System.Collections;

public class AttackAnimationShow : MonoBehaviour {
    //得到攻击的动画
    public Animator playerAnimation;
    public GameObject player;
    //计时器
    private float timer = 0f;
    //技能1的特效
    public GameObject effect1;
    //技能2的特效
    public GameObject effect2;
    //技能3的特效
    public GameObject effect3;
    //技能1的音效
    public AudioSource skill1Sound;
    //技能2的音效
    public AudioSource skill2Sound;
    //技能3的音效
    public AudioSource skill3Sound;
    //判断攻击事件发生的bool
    public bool isAttack=false;
    //单例模式
    public static AttackAnimationShow _instance;

    void Start()
    {
        _instance = this;
    }


    void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            
        }
        else
        {
            player.GetComponent<PlayeMoveInDungeon>().enabled = true;
            isAttack = false;
        }
        StartCoroutine("CloseIsAttack");
    }

	//普通攻击按钮的点击
    public void AttackButtonOnClick()
    {
        playerAnimation.SetTrigger("isAttack");
        player.GetComponent<PlayeMoveInDungeon>().enabled = false;
        timer =0.5f;
        isAttack = true;
    }
    //技能1按钮的点击
    public void Skill1ButtonOnClick()
    {
        isAttack = true;
        playerAnimation.SetTrigger("isSkill1");
        player.GetComponent<PlayeMoveInDungeon>().enabled = false;
        timer = 1f;
        StartCoroutine("EffectShow", effect1);
        skill1Sound.Play();
        
    }
    //技能2按钮的点击
    public void Skill2ButtonOnClick()
    {
        playerAnimation.SetTrigger("isSkill2");
        player.GetComponent<PlayeMoveInDungeon>().enabled = false;
        timer = 1f;
        StartCoroutine("EffectShow", effect2);
        skill2Sound.Play();
        isAttack = true;
    }
    //技能3按钮的点击
    public void Skill3ButtonOnClick()
    {
        playerAnimation.SetTrigger("isSkill3");
        player.GetComponent<PlayeMoveInDungeon>().enabled = false;
        timer = 1.5f;
        StartCoroutine("EffectShow", effect3);
        skill3Sound.Play();
        isAttack = true;
    }

    //特效的启用与销毁
    IEnumerator EffectShow(GameObject effect)
    {
        effect.SetActive(true);
        yield return new WaitForSeconds(1f);
        effect.SetActive(false);
    }

    IEnumerator CloseIsAttack()
    {
        if (isAttack==true)
        {
            yield return new WaitForEndOfFrame();
            isAttack = false;
        }
    }
}

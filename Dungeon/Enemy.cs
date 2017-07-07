using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //获得敌人的角色控制器
    public CharacterController cc;
    //获得玩家的位置
    public Transform playerPos;
    //获得敌人的动画控制器
    public Animator enemyAnimator;
    //设置敌人行走的速度
    public float speed;
    //得到敌人行走的音效
    public AudioSource enemyWalk;
    //得到敌人攻击音效
    public AudioSource enemyAttack;
    //得到玩家动画
    public Animator playerAnimation;
    void Update()
    {
        EnemyMove();
        
    }

    //控制敌人的行走
    void EnemyMove()
    {
        //开始播放行走动画
       
        //敌人朝向玩家
        transform.LookAt(playerPos);
        
        //判断与玩家的距离
        float distance = Vector3.Distance(this.transform.position, playerPos.position);
        if (distance >= 2f)
        {
            //向目标行进
            enemyAnimator.SetBool("isWalk", true);
            cc.SimpleMove(transform.forward * speed);
            enemyWalk.volume = 1;
        }
        else
        {
            //停止行走，攻击
            enemyAnimator.SetBool("isWalk", false);
            enemyAnimator.SetBool("isAttack", true);
            //playerAnimation.SetTrigger("isHit");
            enemyWalk.volume = 0;
        }       
    }

    //敌人音效的播放
    IEnumerator EnemySoundPlay(AudioSource enemySound)
    {
        enemySound.Play();
        yield return new WaitForSeconds(2f);
    }
}

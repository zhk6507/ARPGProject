using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DungeonController : MonoBehaviour {
    //得到所有的敌人
    public List<GameObject> enemyList = new List<GameObject>();
    //得到玩家的位置
    public Transform playerPos;
    void Update()
    {
        EnemyGetHit();
    }

    void EnemyGetHit()
    {
        foreach (GameObject enemy in enemyList)
        {
            float distance = Vector3.Distance(playerPos.position, enemy.transform.position);
            if (distance <= 2f && AttackAnimationShow._instance.isAttack == true)
            {
                enemy.GetComponent<Animator>().SetTrigger("isHit");
            }
            
        }
    }
}

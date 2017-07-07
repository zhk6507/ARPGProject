using UnityEngine;
using System.Collections;

public class PlayerAutoMove : MonoBehaviour {
    //得到Player的NavMeshAgent组件
    public NavMeshAgent agent;
    //单例模式
    public static PlayerAutoMove _instance;

    void Start()
    {
        //单例模式赋值
        _instance = this;
    }
	void Update () {
        if (agent.enabled)//如果自动寻路组件为启用状态
        {
            if (agent.remainingDistance<0.1f&&agent.remainingDistance!=0)//与目标点距离不超过
            {
                //停止自动寻路
                agent.Stop();
                agent.enabled = false;
                MissionManager._instance.ArriveNpc();
            }
        }

        //如果在寻路过程中有按下任意键，停止自动寻路
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h)>0.1f|| Mathf.Abs(v) > 0.1f)
        {
            if (agent.enabled)
            {
                agent.Stop();
                agent.enabled = false;
            }
        }       
	}

    //设置寻路终点的方法
    public void SetDestination(Vector3 targetPos)
    {
        //设置为启用
        agent.enabled = true;
        //自动寻路到targetPos位置
        agent.SetDestination(targetPos);
    }
}

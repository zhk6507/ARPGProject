using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour {

    public Transform missionGridList;
    public GameObject missionItemPrefab;
    
    void Start()
    {
        IntiMissionList();
    }

    //初始化任务列表
    void IntiMissionList()
    {
        //新建一个ArrayLis接收所有的任务信息
        ArrayList missionList = MissionManager._instance.GetMissionList();
        //循环遍历所有的List项
        foreach (Mission item in missionList)
        {
            //生成一个任务，父物体为Grid物体
            GameObject go= Instantiate(missionItemPrefab, missionGridList)as GameObject;
            go.transform.localScale = new Vector3(1f,1f,1f);
            go.transform.localPosition = new Vector3(go.transform.position.x, go.transform.position.y, 0);
            MissionItemUI mi = go.GetComponent<MissionItemUI>();
            mi.SetMission(item);
        }
    }
}

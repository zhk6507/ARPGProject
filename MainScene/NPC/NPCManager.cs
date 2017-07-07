using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPCManager : MonoBehaviour {

    //得到所有NPC
    public GameObject[] npcList;
    //得到副本入口
    public GameObject fbEnter;
    //创建一个字典，存储NPC索引
    private Dictionary<int, GameObject> npcDic = new Dictionary<int, GameObject>();
    //单例模式
    public static NPCManager _instance;

    void Start()
    {
        //单例模式赋值
        _instance = this;
        //初始化字典
        InitNpc();
    }

    //初始化NPC字典的方法
    void InitNpc()
    {
        foreach (var item in npcList)
        {
            int id = int.Parse(item.name.Substring(0,4));
            npcDic.Add(id, item);
        }
    }

    //给外界一个根据NPC的ID获取NPC的方法
    public GameObject GetNpcById(int id)
    {
        GameObject npc = null;
        npcDic.TryGetValue(id,out npc);
        return npc;
    }
}

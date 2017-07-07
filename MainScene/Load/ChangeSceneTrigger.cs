using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour {
    //异步对象
    AsyncOperation async;
    
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        //if (LoadSceneControl.isAsyn)
        //{

        //}
	}

    //IEnumerable OnTriggerEnter(Collider coll)
    //{
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        async = Application.LoadLevelAsync("Dungeon_01");
    //        LoadSceneControl.isAsyn = true;
    //        //读取完毕后返回， 系统会自动进入C场景
    //        yield return async;
    //    }
    //}


}

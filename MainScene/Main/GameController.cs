using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //定义一些静态方法方便调用  
    public static int GetNeedExpByLevel(int level)
    {
        return  (level-2)*(((100+10*(level-2)))/level);
    }
}

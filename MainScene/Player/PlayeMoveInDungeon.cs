using UnityEngine;
using System.Collections;

public class PlayeMoveInDungeon : MonoBehaviour {
    //得到一个位移的速度
    public float speed = 2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //得到x轴向
        float h = Input.GetAxis("Horizontal");
        //得到z轴向
        float v = Input.GetAxis("Vertical");
        //得到player的当前速度
        Vector3 vel = this.gameObject.GetComponent<Rigidbody>().velocity;
        //player的移动控制
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(h * speed, vel.y, v * speed);

        //控制player的朝向（改用if input.keycode试一试）
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            //player的旋转为按下位移的方向
            this.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
        }
    }
}

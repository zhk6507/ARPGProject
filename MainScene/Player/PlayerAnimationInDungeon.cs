using UnityEngine;
using System.Collections;

public class PlayerAnimationInDungeon : MonoBehaviour {
    public Animator playerAnimator;
   
	void Update () {
        //判断，如果player速度不为零，则播放run动画
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.05f)
        {
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }
    }
}

using UnityEngine;
using System.Collections;

public class PlayerAnimationInVillage : MonoBehaviour {
    public Animator playerAnimator;
    public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //判断，如果player速度不为零，则播放run动画
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude>0.05f)
        {
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }       
	}
}

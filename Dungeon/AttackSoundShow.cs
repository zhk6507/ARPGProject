using UnityEngine;
using System.Collections;

public class AttackSoundShow : MonoBehaviour {

    //得到普通攻击的音效
    public AudioSource attackSound;

    //播放攻击音效的方法
    void AttackSoundPlay()
    {
        attackSound.Play();
    }
}

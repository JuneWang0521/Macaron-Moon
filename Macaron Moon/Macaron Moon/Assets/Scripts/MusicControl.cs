using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioClip music;
    private AudioSource back;
    private Transform m_Transform;
    public bool allowPlay = false;

    void Start()
    {
        back = this.GetComponent<AudioSource>();
        back.loop = true; //设置循环播放  
        back.volume = 0.1f;//设置音量最大，区间在0-1之间
        back.clip = music;
        //back.Play(); //播放背景音乐，
    }

    public void checkAllow()
    {
        if(allowPlay)
        {
            back.Play();
        }
    }
}

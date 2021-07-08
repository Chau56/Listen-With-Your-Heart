using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
 //在功能01 - 1的基础上，canMove = true方块开始移动的时候，播放BGM
 // 音乐节奏、速度、音量在方块移动过程不改变
//  预留一个bool值接口(isplaying)，当isPlaying = false的时候BGM音量渐渐减小(要停下来)，音量为0时暂停播放
/// </summary>

public class AudioController : MonoBehaviour
{
    private AudioSource moveAS;
    public bool isPlaying;//isPlaying接口
    private int playTimes=0;//播放次数
    
    private void Awake()
    { 
        moveAS= GetComponent<AudioSource>();//初始化  
        AutoMovement.canMove = true;
    }
     public void FadeOutEffect()
    {
        if (moveAS.volume == 0)
        {
            return;
        }
        moveAS.volume -= 0.1f;
        
    }
     
    private void Play()
    {
        
        if (playTimes == 0)
        {
            playTimes++;
            moveAS.Play();
        }
        return;
        
    }

    //拓展死亡
    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)
        {
            FadeOutEffect();
        }
        if (AutoMovement.canMove == true)
        {
            Play();
        } 
       
    }
}

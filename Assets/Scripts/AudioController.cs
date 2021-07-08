using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
 //�ڹ���01 - 1�Ļ����ϣ�canMove = true���鿪ʼ�ƶ���ʱ�򣬲���BGM
 // ���ֽ��ࡢ�ٶȡ������ڷ����ƶ����̲��ı�
//  Ԥ��һ��boolֵ�ӿ�(isplaying)����isPlaying = false��ʱ��BGM����������С(Ҫͣ����)������Ϊ0ʱ��ͣ����
/// </summary>

public class AudioController : MonoBehaviour
{
    private AudioSource moveAS;
    public bool isPlaying;//isPlaying�ӿ�
    private int playTimes=0;//���Ŵ���
    
    private void Awake()
    { 
        moveAS= GetComponent<AudioSource>();//��ʼ��  
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

    //��չ����
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

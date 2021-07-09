using System.Collections;
using UnityEngine;
/// <summary>
///在功能01 - 1的基础上，canMove = true方块开始移动的时候，播放BGM
/// 音乐节奏、速度、音量在方块移动过程不改变
/// 预留一个bool值接口(isplaying)，当isPlaying = false的时候BGM音量渐渐减小(要停下来)，音量为0时暂停播放
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource moveAS;
    [SerializeField]
    private GameEvents events;
    [SerializeField]
    [Tooltip("淡出音量减小值")]
    [Min(1e-5f)]
    private float decline = 0.1f;
    [SerializeField]
    [Tooltip("淡出音量减小时间间隔")]
    [Min(0)]
    private float interval = 0.01f;
    private float volume;
    //[SerializeField]
    //private bool pause = false;//isPlaying接口
    //private int playTimes = 0;//播放次数

    private void Start()
    {
        moveAS = GetComponent<AudioSource>();//初始化  
        volume = moveAS.volume;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameFailed += Stop;
        events.GameResume += Unpause;
        events.GamePause += Pause;
    }
    private void Pause()
    {
        StartCoroutine(FadeOutEffect());
    }
    //private void Play()
    //{
    //    moveAS.Play();
    //}
    private void Unpause()
    {
        FadeInEffect();
    }
    private void Stop()
    {
        moveAS.Stop();
    }

    private IEnumerator FadeOutEffect()
    {
        while (moveAS.volume > 0)
        {
            moveAS.volume -= decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        moveAS.Pause();
    }
    private IEnumerator FadeInEffect()
    {
        while (moveAS.volume < volume)
        {
            moveAS.volume += decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        moveAS.UnPause();
    }


    //private void Play()
    //{
    //    if (playTimes == 0)
    //    {
    //        playTimes++;
    //        moveAS.Play();
    //    }
    //    return;
    //}

    //拓展死亡
    // Update is called once per frame
    //private void Update()
    //{
    //if (isPlaying == false)
    //{
    //    FadeOutEffect();
    //}
    //if (AutoMovement.canMove == true)
    //{
    //    Play();
    //} 

    //}
}

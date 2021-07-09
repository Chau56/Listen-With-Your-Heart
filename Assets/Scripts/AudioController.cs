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
    [SerializeField]
    [Tooltip("最大音量。会覆盖AudioSource的音量。")]
    [Range(0, 1)]
    private float volume;
    /// <summary>
    /// 最大音量。
    /// </summary>
    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            if (value < 0) volume = 0;
            else if (value > 1) volume = 1;
            else volume = value;
        }
    }

    private void Start()
    {
        moveAS = GetComponent<AudioSource>();//初始化  
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
        StartCoroutine(FadeOutEffect(false));
    }
    //private void Play()
    //{
    //    moveAS.Play();
    //}
    private void Unpause()
    {
        StartCoroutine(FadeInEffect(false));
    }
    private void Stop()
    {
        StartCoroutine(FadeOutEffect(true));
    }

    private IEnumerator FadeOutEffect(bool stop)
    {
        Debug.Log($"fadeout stop {stop}");
        while (moveAS.volume > 0)
        {
            moveAS.volume -= decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        if (stop) moveAS.Stop();
        else moveAS.Pause();
    }
    private IEnumerator FadeInEffect(bool play)
    {
        Debug.Log($"fadein play {play}");
        while (moveAS.volume < Volume)
        {
            moveAS.volume += decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        if (play) moveAS.Play();
        else moveAS.UnPause();
    }
}

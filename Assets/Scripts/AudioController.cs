using System.Threading;
using System.Threading.Tasks;
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
    private GameEvents events;
    [SerializeField]
    [Tooltip("淡出音量减小值")]
    [Min(1e-5f)]
    private float decline = 0.01f;
    [SerializeField]
    [Tooltip("淡出音量减小时间间隔，单位毫秒")]
    [Min(0)]
    private int interval = 10;
    [SerializeField]
    [Tooltip("最大音量。会覆盖AudioSource的音量。")]
    [Range(0, 1)]
    private float volume;
    private CancellationTokenSource source;
    /// <summary>
    /// 最大音量。
    /// </summary>
    //public float Volume
    //{
    //    get
    //    {
    //        return volume;
    //    }
    //    set
    //    {
    //        if (value < 0) volume = 0;
    //        else if (value > 1) volume = 1;
    //        else volume = value;
    //    }
    //}

    private void Start()
    {
        events = GameEvents.instance;
        moveAS = GetComponent<AudioSource>();//初始化  
        source = new CancellationTokenSource();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameEnd += Stop;
        events.GameResume += Unpause;
        events.GamePause += Pause;
        events.GameStart += Play;
    }
    private void CancelSource()
    {
        source.Cancel();
        source = new CancellationTokenSource();
    }
    private void Pause()
    {
        moveAS.Pause();
    }
    private void Play()
    {
        CancelSource();
        _ = FadeInEffect(true, source.Token);
    }
    private void Unpause()
    {
        moveAS.UnPause();
    }
    private void Stop()
    {
        CancelSource();
        _ = FadeOutEffect(true, source.Token);
    }

    private async Task FadeOutEffect(bool stop, CancellationToken token)
    {
        Debug.Log($"music fadeout may stop {stop}");
        while (moveAS.volume > 0)
        {
            moveAS.volume -= decline;
            await Task.Delay(interval, token);
        }
        if (token.IsCancellationRequested) return;
        if (stop) moveAS.Stop();
        else moveAS.Pause();
    }

    private async Task FadeInEffect(bool play, CancellationToken token)
    {
        Debug.Log($"music fadein may play {play}");
        if (play) moveAS.Play();
        else moveAS.UnPause();
        while (moveAS.volume < volume)
        {
            moveAS.volume += decline;
            await Task.Delay(interval, token);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
///�ڹ���01 - 1�Ļ����ϣ�canMove = true���鿪ʼ�ƶ���ʱ�򣬲���BGM
/// ���ֽ��ࡢ�ٶȡ������ڷ����ƶ����̲��ı�
/// Ԥ��һ��boolֵ�ӿ�(isplaying)����isPlaying = false��ʱ��BGM����������С(Ҫͣ����)������Ϊ0ʱ��ͣ����
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource moveAS;
    private GameEvents events;
    [SerializeField]
    [Tooltip("����������Сֵ")]
    [Min(1e-5f)]
    private float decline = 0.01f;
    [SerializeField]
    [Tooltip("����������Сʱ��������λ����")]
    [Min(0)]
    private int interval = 10;
    [SerializeField]
    [Tooltip("����������Ḳ��AudioSource��������")]
    [Range(0, 1)]
    private float volume;
    private CancellationTokenSource source;
    /// <summary>
    /// ���������
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
        moveAS = GetComponent<AudioSource>();//��ʼ��  
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

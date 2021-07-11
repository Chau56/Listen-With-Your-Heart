using System.Collections;
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
    [SerializeField]
    private GameEvents events;
    [SerializeField]
    [Tooltip("����������Сֵ")]
    [Min(1e-5f)]
    private float decline = 0.1f;
    [SerializeField]
    [Tooltip("����������Сʱ����")]
    [Min(0)]
    private float interval = 0.01f;
    [SerializeField]
    [Tooltip("����������Ḳ��AudioSource��������")]
    [Range(0, 1)]
    private float volume;
    private int coroutining;
    /// <summary>
    /// ���������
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
        moveAS = GetComponent<AudioSource>();//��ʼ��  
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameFailed += Stop;
        events.GameResume += Unpause;
        events.GamePause += Pause;
        events.GameStart += Play;
    }
    private void Pause()
    {
        StartCoroutine(FadeOutEffect(false));
    }
    private void Play()
    {
        StartCoroutine(FadeInEffect(true));
    }
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
        Debug.Log($"fadeout may stop {stop}");
        coroutining += 1;
        while (moveAS.volume > 0 && coroutining == 1)
        {
            moveAS.volume -= decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        coroutining -= 1;
        if (stop) moveAS.Stop();
        else moveAS.Pause();
    }
    private IEnumerator FadeInEffect(bool play)
    {
        Debug.Log($"fadein may play {play}");
        coroutining += 1;
        while (moveAS.volume < Volume && coroutining == 1)
        {
            moveAS.volume += decline;
            yield return new WaitForSecondsRealtime(interval);
        }
        coroutining -= 1;
        if (play) moveAS.Play();
        else moveAS.UnPause();
    }
}

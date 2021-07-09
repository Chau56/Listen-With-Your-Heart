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
    private float volume;
    //[SerializeField]
    //private bool pause = false;//isPlaying�ӿ�
    //private int playTimes = 0;//���Ŵ���

    private void Start()
    {
        moveAS = GetComponent<AudioSource>();//��ʼ��  
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

    //��չ����
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

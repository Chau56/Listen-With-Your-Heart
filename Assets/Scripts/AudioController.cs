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
    private bool isPlaying = true;//isPlaying�ӿ�
    private int playTimes = 0;//���Ŵ���

    private void Start()
    {
        moveAS = GetComponent<AudioSource>();//��ʼ��  
        var input = InGameActionDistribute.instance;
        input.GameResume += Play;
        input.GamePause += Pause;
        events.GameFailed += Pause;
    }
    private void Pause()
    {
        isPlaying = false;
    }
    public void FadeOutEffect()
    {
        while (moveAS.volume <= 0)
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
    private void Update()
    {
        if (isPlaying == false)
        {
            FadeOutEffect();
        }
        //if (AutoMovement.canMove == true)
        //{
        //    Play();
        //} 

    }
}

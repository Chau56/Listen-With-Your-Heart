using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackMusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    [Tooltip("���ֵ�����ʱ��")]
    private float fadeTime=1.0f;
    [SerializeField]
    [Tooltip("���������������source�и��ĺ���������ģ������������������ֵ��")]
    private float maxMusicVolume = 1.0f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MusicFadeOut()
    {
        Debug.Log("��Ƶ������ִ��");
        StartCoroutine(MusicFade());
    }

    private IEnumerator MusicFade()
    {
        float time = 0;
        while (time <= fadeTime) 
        {
            if(time!=0)
            audioSource.volume = Mathf.Lerp(maxMusicVolume,0f,time/fadeTime);

            time += Time.deltaTime;
            yield return 1;
        }
        audioSource.volume = 0;
    }
}

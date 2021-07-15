using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackMusicControl : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField]
    [Tooltip("音乐淡出总时间")]
    private float fadeTime=1.0f;
    [SerializeField]
    [Tooltip("音乐最大音量（在source中更改后在这里更改，这里是音量渐变最大值）")]
    private float maxMusicVolume = 1.0f;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void MusicFadeOut()
    {
        Debug.Log("音频减弱已执行");
        StartCoroutine(MusicFade());
    }

    private IEnumerator MusicFade()
    {
        float time = 0;
        while (time <= fadeTime) 
        {
            if(time!=0)
            AudioSource.volume = Mathf.Lerp(maxMusicVolume,0f,time/fadeTime);

            time += Time.deltaTime;
            yield return 1;
        }
        AudioSource.volume = 0;
    }
}

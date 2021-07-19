///<summary>
///作者：张子龙
///创建日期：2021-7-15
///更新者：周权
///最新修改日期：2021-7-17
///</summary>


using System.Collections;
using UnityEngine;

public class StartBackMusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    [Tooltip("音乐淡出总时间")]
    private float fadeTime = 1.0f;
    [SerializeField]
    [Tooltip("音乐最大音量（在source中更改后在这里更改，这里是音量渐变最大值）")]
    private float maxMusicVolume = 1.0f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if (time != 0)
                audioSource.volume = Mathf.Lerp(maxMusicVolume, 0f, time / fadeTime);

            time += Time.deltaTime;
            yield return 1;
        }
        audioSource.volume = 0;
    }
}

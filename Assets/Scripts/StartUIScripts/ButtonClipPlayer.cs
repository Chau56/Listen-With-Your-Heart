///<summary>
///作者：张子龙
///创建日期：2021-7-16
///更新者：周权
///最新修改日期：2021-7-17
///</summary>


using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonClipPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    [Tooltip("要播放的音效")]
    private AudioClip audioClip;
    [SerializeField]
    [Tooltip("音效音量大小")]
    private float soundVolume = 1.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClipPlay()
    {
        if (audioClip != null)
            audioSource.PlayOneShot(audioClip, soundVolume);
    }

}

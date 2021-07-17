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

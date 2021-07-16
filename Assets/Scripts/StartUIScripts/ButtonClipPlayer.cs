using System.Collections;
using System.Collections.Generic;
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
    private float soundVolume=1.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClipPlay()
    {
        audioSource.PlayOneShot(audioClip, soundVolume);
    }
        
}

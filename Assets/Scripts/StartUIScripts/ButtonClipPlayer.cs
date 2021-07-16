using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClipPlayer : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField]
    [Tooltip("要播放的音效")]
    private AudioClip AudioClip;
    [SerializeField]
    [Tooltip("音效音量大小")]
    private float soundVolume=1.0f;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ButtonClipPlay()
    {
        AudioSource.PlayOneShot(AudioClip, soundVolume);
    }
        
}

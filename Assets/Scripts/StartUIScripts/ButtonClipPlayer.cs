using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClipPlayer : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField]
    [Tooltip("Ҫ���ŵ���Ч")]
    private AudioClip AudioClip;
    [SerializeField]
    [Tooltip("��Ч������С")]
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

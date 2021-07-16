using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonClipPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    [Tooltip("Ҫ���ŵ���Ч")]
    private AudioClip audioClip;
    [SerializeField]
    [Tooltip("��Ч������С")]
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

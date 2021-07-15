using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipPlay : SwitchBehavior
{
    [SerializeField]
    [Tooltip("��Ч������С")]
    private float soundValue = 1.0f;
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip AudioClip;

    private bool audioCanPlay;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        RegisterSomeEvents();
    }

    private void RegisterSomeEvents()
    {
        events.GameAwake +=()=> audioCanPlay = true;

        Swicher(() =>
        {
            events.BlackDying += () => audioCanPlay = false;
            events.BlackReviving += () => audioCanPlay = true;
        }, () =>
        {
            events.WhiteDying += () => audioCanPlay = false;
            events.WhiteReviving += () => audioCanPlay = true;
        }
            );

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Road" && audioCanPlay)
        {
            if (AudioSource.isPlaying)
                AudioSource.Stop();
            Debug.Log("��Ч�Ѳ���");

            AudioSource.PlayOneShot(AudioClip, soundValue);

        }

        if (collision.gameObject.tag == "Stair" && audioCanPlay)
        {
            if (AudioSource.isPlaying)
                AudioSource.Stop();
            Debug.Log("��Ч�Ѳ���");
            AudioSource.PlayOneShot(AudioClip, soundValue);
        }




    }



}
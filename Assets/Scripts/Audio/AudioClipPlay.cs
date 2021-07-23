///<summary>
///作者：张子龙
///创建日期：2021-7-15
///更新者：周权
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

public class AudioClipPlay : SwitchBehavior
{
    [SerializeField]
    [Tooltip("音效声音大小")]
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
        events.GameAwake += () => audioCanPlay = true;

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
            Debug.Log("音效已播放");

            AudioSource.PlayOneShot(AudioClip, soundValue);

        }

        if (collision.gameObject.tag == "Stair" && audioCanPlay)
        {
            if (AudioSource.isPlaying)
                AudioSource.Stop();
            Debug.Log("音效已播放");
            AudioSource.PlayOneShot(AudioClip, soundValue);
        }




    }



}

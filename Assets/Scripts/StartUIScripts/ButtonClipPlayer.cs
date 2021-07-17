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

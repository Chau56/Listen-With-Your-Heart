using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WinSound : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var sound = GetComponent<AudioSource>();
        var events = GameEvents.instance;
        events.GameWin += sound.Play;
        events.GameBeforeAwake += sound.Stop;
    }
}

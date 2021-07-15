using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PauseBackground : MonoBehaviour
{
    private GameEvents events;
    private Animator anima;
    // Start is called before the first frame update
    private void Start()
    {
        events = GameEvents.instance;
        anima = GetComponent<Animator>();
        events.GamePause += Pause;
        events.GameResume += Resume;
        events.GameEnd += Resume;
    }

    private void Pause()
    {
        anima.SetBool("Pause", true);
    }

    private void Resume()
    {
        anima.SetBool("Pause", false);
    }
}

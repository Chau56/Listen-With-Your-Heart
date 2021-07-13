using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PauseBackground : MonoBehaviour
{
    private GameEvents events;
    private Image image;
    // Start is called before the first frame update
    private void Start()
    {
        events = GameEvents.instance;
        image = GetComponent<Image>();
        events.GamePause += Pause;
        events.GameResume += Resume;
        events.GameAbnormalEnd += Resume;
        Resume();
    }

    private void Pause()
    {
        image.enabled = true;
    }

    private void Resume()
    {
        image.enabled = false;
    }
}

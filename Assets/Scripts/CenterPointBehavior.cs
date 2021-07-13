using UnityEngine;

public class CenterPointBehavior : MonoBehaviour
{
    private GameEvents events;
    private void Awake()
    {
        events = GameEvents.instance;
        gameObject.SetActive(false);
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GamePause += Activate;
        events.GameResume += Deactivate;
        events.GameAbnormalEnd += Deactivate;
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

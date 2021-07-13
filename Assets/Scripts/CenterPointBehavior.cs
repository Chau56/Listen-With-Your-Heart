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
        events.GamePause += () => gameObject.SetActive(true);
        events.GameResume += () => gameObject.SetActive(false);
    }
}

using UnityEngine;

public class StartPointBehavior : MonoBehaviour
{
    private GameEvents events;
    private void Awake()
    {
        events = GameEvents.instance;
        RegisterEvnets();
    }

    private void RegisterEvnets()
    {
        events.GamePause += Deactivate;
        events.GameResume += Activate;
        events.GameEnd += Activate;
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

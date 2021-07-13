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
        events.GamePause += () => gameObject.SetActive(false);
        events.GameResume += () => gameObject.SetActive(true);
    }
}

using UnityEngine;

public class WinCenter : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        var events = GameEvents.instance;
        events.GameWin += Activate;
        events.GameAwake += Deactivate;
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

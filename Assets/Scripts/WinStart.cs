using UnityEngine;

public class WinStart : MonoBehaviour
{
    private void Awake()
    {
        RegisterEvnets();
    }

    private void RegisterEvnets()
    {
        var events = GameEvents.instance;
        events.GameWin += Deactivate;
        events.GameAwake += Activate;
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

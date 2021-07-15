using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RenewDistance : MonoBehaviour
{
    [SerializeField]
    private Distance distance;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        RegisterEvents();
    }
    private void RegisterEvents()
    {
        var events = GameEvents.instance;
        events.GameWin += Renew;
    }
    private void Renew()
    {
        text.text = distance.Value.ToString();
    }
}

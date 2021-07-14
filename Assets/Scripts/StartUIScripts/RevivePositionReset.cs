using UnityEngine;

public class RevivePositionReset : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("多长时间后复活，单位毫秒")]
    private int reviveTime;

    private void Start()
    {
        events = GameEvents.instance;
        events.GameEnd += Restart;
        _ = events.StartGame(reviveTime, 10);
    }

    private void Restart()
    {
        _ = events.StartGame(reviveTime, 10);
    }
}

using System.Threading;
using UnityEngine;

public class RevivePositionReset : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("多长时间后复活，单位毫秒")]
    private int reviveTime;
    public CancellationTokenSource Source
    {
        get;
        private set;
    }

    private void Start()
    {
        Source = new CancellationTokenSource();
        events = GameEvents.instance;
        events.GameEnd += Restart;
        Restart();
    }

    private void Restart()
    {
        _ = events.StartGame(0, reviveTime, 10, Source.Token);
    }
}

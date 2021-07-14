using UnityEngine;

public class RevivePositionReset : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("�೤ʱ��󸴻��λ����")]
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

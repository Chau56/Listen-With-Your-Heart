using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    private GameEvents events;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    [Tooltip("�����ƶ���")]
    private Vector2 velocity = new Vector2(8.5f, 0);
    private Vector2 startPosition;
    /// <summary>
    /// ʩ����������
    /// </summary>
    private void Run()
    {
        rigidbody.velocity = velocity;
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    private void Stop()
    {
        rigidbody.velocity = Vector2.zero;
    }

    private void Reset()
    {
        rigidbody.MovePosition(startPosition);
    }
    private void Start()
    {
        startPosition = transform.position;
        events = GameEvents.instance;
        rigidbody = GetComponent<Rigidbody2D>();
        events.GameAwake += Reset;
        events.GameStart += Run;
        events.GamePause += Stop;
        events.GameResume += Run;
        events.GameEnd += Stop;
    }

}

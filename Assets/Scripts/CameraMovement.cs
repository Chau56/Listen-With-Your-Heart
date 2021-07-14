using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    private GameEvents events;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    [Tooltip("物体移动力")]
    private Vector2 velocity = new Vector2(8.5f, 0);
    private Vector2 startPosition;
    /// <summary>
    /// 施加脉冲力。
    /// </summary>
    private void Run()
    {
        rigidbody.velocity = velocity;
    }
    /// <summary>
    /// 速度归零。
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

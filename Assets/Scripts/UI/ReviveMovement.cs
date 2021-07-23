///<summary>
///作者：周权
///创建日期：2021-7-8
///更新者：张子龙
///最新修改日期：2021-7-16
///</summary>


using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ReviveMovement : MonoBehaviour
{
    private GameEvents events;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    [Tooltip("物体移动力")]
    private Vector2 velocity = new Vector2(8.5f, 0);
    private Vector3 startPosition;
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
        transform.position = startPosition;
    }
    private void Start()
    {
        startPosition = transform.position;
        events = GameEvents.instance;
        rigidbody = GetComponent<Rigidbody2D>();
        events.GameBeforeAwake += Reset;
        events.GameStart += Run;
        events.GamePause += Stop;
        events.GameResume += Run;
        events.GameEnd += Stop;
    }

}

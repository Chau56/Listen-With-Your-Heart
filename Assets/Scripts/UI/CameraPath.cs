///<summary>
///作者：周权
///创建日期：2021-7-20
///最新修改日期：2021-7-21
///</summary>


using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraPath : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private Vector2 speed;
    private Vector3 startPosition;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        var events = GameEvents.instance;
        events.GameStart += Run;
        events.GamePause += Stop;
        events.GameResume += Run;
        events.GameEnd += Stop;
        events.GameBeforeAwake += ResetPosition;
    }
    private void Run()
    {
        rigidbody.velocity = speed;
    }
    private void Stop()
    {
        rigidbody.velocity = Vector2.zero;
    }
    private void ResetPosition()
    {
        transform.position = startPosition;
    }
    private void DetectTag(Collider2D collision)
    {
        if (collision.CompareTag("Endline"))
        {
            Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectTag(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectTag(collision);
    }
}

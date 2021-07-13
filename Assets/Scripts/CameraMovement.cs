using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    //[SerializeField]
    private bool moveable;
    private GameEvents events;
    private new Rigidbody2D rigidbody;
    //private float speedPerFrame;
    private void Start()
    {
        events = GameEvents.instance;
        rigidbody = GetComponent<Rigidbody2D>();
        events.GameFailed += Stay;
        events.GameStart += Move;
        events.GamePause += Stay;
        events.GameResume += Move;
        events.GameWin += Stay;
    }
    private void Stay()
    {
        moveable = false;
    }
    private void Move()
    {
        moveable = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moveable) rigidbody.MovePosition(transform.position + Vector3.right * speed / 50);
    }
}

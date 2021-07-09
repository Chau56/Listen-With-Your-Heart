using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    //[SerializeField]
    private bool moveable;
    [SerializeField]
    private GameEvents events;
    //private float speedPerFrame;
    private void Start()
    {
        events.GameEnd += Stay;
        events.GameStart += Move;
        events.GamePause += Stay;
        events.GameResume += Move;
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
        if (moveable) transform.Translate(Vector3.right * speed / 50);
    }
}

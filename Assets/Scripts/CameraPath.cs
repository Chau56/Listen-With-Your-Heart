using UnityEngine;

public class CameraPath : MonoBehaviour
{
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float speed;
    private Vector3 startPosition;
    private float totalTime, curTime;
    private bool running;
    private void Start()
    {
        startPosition = transform.position;
        totalTime = (endPosition.x - startPosition.x) / speed;
        var events = GameEvents.instance;
        events.GameStart += Run;
        events.GamePause += Stop;
        events.GameResume += Run;
        events.GameEnd += Stop;
        events.GameBeforeAwake += ResetPosition;
    }
    private void Run()
    {
        running = true;
    }
    private void Stop()
    {
        running = false;
    }
    private void ResetPosition()
    {
        transform.position = startPosition;
        curTime = 0;
    }
    private void Update()
    {
        if (running)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, curTime / totalTime);
            curTime += Time.deltaTime;
        }
    }
}

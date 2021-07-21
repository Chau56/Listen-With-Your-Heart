using UnityEngine;

public class CameraPath : MonoBehaviour
{
    [SerializeField]
    private float endPositionX;
    [SerializeField]
    private float speed;
    private float startX;
    private float time;
    private void Start()
    {
        startX = transform.position.x;
        time = (endPositionX - startX) / speed;
    }
}

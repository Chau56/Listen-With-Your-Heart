using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("�����ƶ��ٶ�")]
    private Vector2 speed = new Vector2(8.5f, 0);
    //[SerializeField]
    //[Tooltip("�����ٶ�������ֵ�����������ٶ���ʵ���ٶȲ����ֵ��������")]
    //private float threshold = 0.5f;
    [SerializeField]
    private GameEvents events;
    private Vector2 velocityPaused;
    /// <summary>
    /// ʩ����������
    /// </summary>
    private void Impulse()
    {
        myRigidbody.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} impulse velocity {myRigidbody.velocity}");
    }
    private void Resume()
    {
        myRigidbody.velocity = velocityPaused;
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    private void Pause()
    {
        velocityPaused = myRigidbody.velocity;
        myRigidbody.velocity = Vector2.zero;
    }

    //private void AmendSpeed()
    //{
    //    float x = myRigidbody.velocity.x, speedX = speed.x - threshold;
    //    if (x > 1 && x < speedX)
    //    {
    //        Debug.Log($"amend {tag}");
    //        myRigidbody.AddForce(new Vector2(speedX - x, 0), ForceMode2D.Impulse);
    //    }
    //}

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameStart += Impulse;
        events.GamePause += Pause;
        events.GameResume += Resume;
    }

    //private void FixedUpdate()
    //{
    //    AmendSpeed();
    //}
}

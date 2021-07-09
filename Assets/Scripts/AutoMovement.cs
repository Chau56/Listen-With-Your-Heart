using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("�����ƶ��ٶ�")]
    private Vector2 speed = new Vector2(8.5f, 0);
    [SerializeField]
    private GameEvents events;
    /// <summary>
    /// ʩ����������
    /// </summary>
    private void Impulse()
    {
        myRigidbody.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} velocity {myRigidbody.velocity}");
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    private void Pause()
    {
        myRigidbody.velocity = Vector2.zero;
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameStart += Impulse;
        events.GamePause += Pause;
        events.GameResume += Impulse;
    }
}

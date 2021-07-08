using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("����һ��������ϾͿ�ʼ�ƶ���")]
    private bool MoveOnStart;
    [SerializeField]
    [Tooltip("�����ƶ��ٶ�")]
    private float speed;
    [SerializeField]
    [Tooltip("�����ĸ���ң�")]
    private PlayerEnum player;
    /// <summary>
    /// ʩ����������
    /// </summary>
    private void Impulse()
    {
        myRigidbody.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} velocity {myRigidbody.velocity}");
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    private void Pause()
    {
        myRigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        Debug.Log($"{tag} velocity {myRigidbody.velocity}");
    }
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        if (MoveOnStart) Impulse();
        var input = InGameActionDistribute.instance;
        switch (player)
        {
            case PlayerEnum.Black:
                input.Impulse1 += Impulse;
                input.Pause1 += Pause;
                break;
            case PlayerEnum.White:
                input.Impulse2 += Impulse;
                input.Pause2 += Pause;
                break;
        }
    }
}

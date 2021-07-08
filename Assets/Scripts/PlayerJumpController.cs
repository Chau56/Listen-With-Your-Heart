using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��Ծ�ٶȡ�")]
    private float jumpSpeed = 3f;
    private Rigidbody2D rigidBody;
    [SerializeField]
    [Tooltip("�����ĸ���ң�")]
    private PlayerEnum player;
    /// <summary>
    /// ��¶�Ľӿڣ�ָʾ�Ƿ�����Ծ��
    /// </summary>
    public bool IsJumping
    {
        get
        {
            return !canJump;
        }
    }
    /// <summary>
    /// ָʾ�ܷ���Ծ��
    /// </summary>
    private bool canJump;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        var input = InGameActionDistribute.instance;
        switch (player)
        {
            case PlayerEnum.Black:
                input.Jump1 += Jump;
                break;
            case PlayerEnum.White:
                input.Jump2 += Jump;
                break;
        }
    }
    /// <summary>
    /// ���þͿ�������
    /// </summary>
    public void Jump()
    {
        Debug.Log($"{tag} will jump.");
        if (canJump)
        {
            Debug.Log($"{tag} jumped.");
            rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//�����ײ����ײ����������canJump�����������ܹ���һ����Ծ����
    {
        Debug.Log($"{tag} enter {collision.collider.tag}");
        //if (collision.collider.CompareTag(groundTag))
        canJump = true;
    }
}
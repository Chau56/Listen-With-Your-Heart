using UnityEngine;
using UnityEngine.InputSystem;

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
    private bool jumpPressed;
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
                input.Jump1Start += JumpStart;
                input.Jump1Finished += JumpFinished;
                break;
            case PlayerEnum.White:
                input.Jump2Start += JumpStart;
                input.Jump2Finished += JumpFinished;
                break;
        }
    }
    private void JumpStart()
    {
        Debug.Log($"{tag} will jump.");
        jumpPressed = true;
    }
    private void JumpFinished()
    {
        Debug.Log($"{tag} will stop jumping.");
        jumpPressed = false;
    }
    /// <summary>
    /// ���þͿ�������
    /// </summary>
    public void Jump()
    {
        if (canJump && jumpPressed)
        {
            Debug.Log($"{tag} jumped.");
            rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)//�����ײ����ײ����������canJump�����������ܹ���һ����Ծ����
    {
        Debug.Log($"{tag} enter {collision.collider.tag}");
        //if (collision.collider.CompareTag(groundTag))
        canJump = true;
    }
}
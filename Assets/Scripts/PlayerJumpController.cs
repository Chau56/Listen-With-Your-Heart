using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : SwitchBehavior
{
    [SerializeField]
    [Tooltip("��Ծ�ٶȡ�")]
    private Vector2 jumpSpeed = new Vector2(0, 17);
    private Rigidbody2D rigidBody;
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
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        Swicher(() =>
        {
            events.Jump1Start += JumpStart;
            events.Jump1Finished += JumpFinished;
        }, () =>
        {
            events.Jump2Start += JumpStart;
            events.Jump2Finished += JumpFinished;
        });
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

    private void Jump()
    {
        if (canJump && jumpPressed)
        {
            Debug.Log($"{tag} jumped.");
            rigidBody.AddForce(jumpSpeed, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)//�����ײ����ײ����������canJump�����������ܹ���һ����Ծ����
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
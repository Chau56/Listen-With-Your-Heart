///<summary>
///作者：张子龙
///创建日期：2021-7-7
///更新者：周权、施欣怡
///最新修改日期：2021-7-14
///</summary>


using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : SwitchBehavior
{
    [SerializeField]
    [Tooltip("跳跃速度。")]
    private Vector2 jumpSpeed = new Vector2(0, 17);
    [SerializeField]
    private GameObject revivePosition;
    private string reviveTag;
    private Rigidbody2D rigidBody;
    private bool jumpPressed;
    /// <summary>
    /// 暴露的接口，指示是否在跳跃。
    /// </summary>
    public bool IsJumping
    {
        get
        {
            return !canJump;
        }
    }
    private bool canJump;

    private void Start()
    {
        reviveTag = revivePosition.tag;
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

    private void OnCollisionEnter2D(Collision2D collision)//检测碰撞当碰撞发生后重置canJump让物体重新能够有一次跳跃机会
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(reviveTag)) canJump = false;
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("跳跃速度。")]
    private Vector2 jumpSpeed = new Vector2(0, 17);
    private Rigidbody2D rigidBody;
    [SerializeField]
    [Tooltip("这是哪个玩家？")]
    private PlayerEnum player;
    private bool jumpPressed;
    [SerializeField]
    private GameEvents events;
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
    /// <summary>
    /// 指示能否跳跃。
    /// </summary>
    private bool canJump;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        switch (player)
        {
            case PlayerEnum.Black:
                events.Jump1Start += JumpStart;
                events.Jump1Finished += JumpFinished;
                break;
            case PlayerEnum.White:
                events.Jump2Start += JumpStart;
                events.Jump2Finished += JumpFinished;
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
}
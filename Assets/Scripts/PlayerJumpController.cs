using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("跳跃速度。")]
    private float jumpSpeed = 3f;
    private Rigidbody2D rigidBody;
    [SerializeField]
    [Tooltip("这是哪个玩家？")]
    private PlayerEnum player;
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
    /// 调用就可能跳。
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

    private void OnCollisionEnter2D(Collision2D collision)//检测碰撞当碰撞发生后重置canJump让物体重新能够有一次跳跃机会
    {
        Debug.Log($"{tag} enter {collision.collider.tag}");
        //if (collision.collider.CompareTag(groundTag))
        canJump = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("跳跃速度。")]
    private float jumpSpeed = 3f;
    private Rigidbody2D rigidBody;
    private Vector2 vectorYPower;
    [SerializeField]
    [Tooltip("地面。所有和这个物体tag相同的都被看作地面。")]
    private GameObject ground;
    private string groundTag;
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
        Debug.Assert(ground, ground);
        rigidBody = GetComponent<Rigidbody2D>();
        Debug.Assert(rigidBody, rigidBody);
        vectorYPower = new Vector2(0, jumpSpeed);
        groundTag = ground.tag;
    }
    /// <summary>
    /// 调用就可能跳。
    /// </summary>
    public void Jump(InputAction.CallbackContext _)
    {
        Debug.Log($"{tag} jumped.");
        if (canJump)//判断玩家有无输入A键，输入则跳跃
        {
            //canJump用来记录方块是否落地，初始为true,当发生碰撞被检测后被重置为true
            rigidBody.AddForce(vectorYPower, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//检测碰撞当碰撞发生后重置canJump让物体重新能够有一次跳跃机会
    {
        if (collision.collider.CompareTag(groundTag))
            canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            canJump = false;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��Ծ�ٶȡ�")]
    private float jumpSpeed = 3f;
    private Rigidbody2D rigidBody;
    //[SerializeField]
    //[Tooltip("���档���к��������tag��ͬ�Ķ����������档")]
    //private GameObject ground;
    //private string groundTag;
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
        //Debug.Assert(ground, ground);
        rigidBody = GetComponent<Rigidbody2D>();
        //groundTag = ground.tag;
    }
    /// <summary>
    /// ���þͿ�������
    /// </summary>
    public void Jump(InputAction.CallbackContext _)
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
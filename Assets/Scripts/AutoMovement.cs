using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("�����ƶ��ٶ�")]
    private float speed = 8f;
    [SerializeField]
    [Tooltip("�����ð���")]
    private InGameActionDistribute input;
    /// <summary>
    /// ʩ����������
    /// </summary>
    public void Impulse()
    {
        myRigidbody.AddForce(Vector2.right*speed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    public void Pause()
    {
        myRigidbody.velocity = Vector2.zero;
    }
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Impulse();
    }
}

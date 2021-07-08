using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("物体移动速度")]
    private float speed = 8f;
    [SerializeField]
    [Tooltip("作弊用按键")]
    private InGameActionDistribute input;
    /// <summary>
    /// 施加脉冲力。
    /// </summary>
    public void Impulse()
    {
        myRigidbody.AddForce(Vector2.right*speed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// 速度归零。
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

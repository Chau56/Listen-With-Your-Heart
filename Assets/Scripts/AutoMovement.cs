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
    [Tooltip("控制方块暂停")]
    private bool canMove = true;

    private void FixedUpdate()
    {
        if (canMove)
        {
            myRigidbody.AddForce(Vector2.right * speed);
        }
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
}

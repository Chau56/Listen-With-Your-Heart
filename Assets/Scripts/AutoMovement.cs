using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class AutoMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 8f;      //物体移动速度
    [SerializeField] bool canMove = true;    //控制方块暂停

    void FixedUpdate()
    {
        if (canMove)
        {
            myRigidbody.AddForce(Vector2.right * speed);
        }
    }

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class AutoMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 8f;      //�����ƶ��ٶ�
    [SerializeField] bool canMove = true;    //���Ʒ�����ͣ

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

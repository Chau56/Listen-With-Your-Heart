using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 8f;      //�����ƶ��ٶ�
    public static  bool canMove = true;    //���Ʒ�����ͣ

    void Update()
    {
        if (canMove)
        {
            myRigidbody.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }
}

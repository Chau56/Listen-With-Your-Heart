using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] public float speed = 5f;      //�����ƶ��ٶ�
    [SerializeField] public bool canMove = true;    //���Ʒ�����ͣ

    void Update()
    {
        if (canMove == true)
        {
            myRigidbody.transform.Translate(speed * Time.deltaTime, 0, 0);  
        }
    }

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }
}

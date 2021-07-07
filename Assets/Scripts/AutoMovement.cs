using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 5f;      //方块移动速度
    [SerializeField] bool canMove = true;    //控制方块暂停

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

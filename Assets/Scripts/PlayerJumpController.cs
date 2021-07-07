using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float yPower = 400f;
    [SerializeField] string controllerButton = "Jump";
    [SerializeField] float speed = 9.0f;//char controlKey;
    Rigidbody2D rig;
    bool canJump;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        canJump = true;

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //跳跃测试用移动
        /*Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;*/
        if (Input.GetButton(controllerButton))//判断玩家有无输入A键，输入则跳跃
        {

            if (canJump == true)//canJump用来记录方块是否落地，初始为true,当发生碰撞被检测后被重置为true
            {
                rig.AddForce(new Vector2(0,  yPower), ForceMode2D.Force);
                canJump = false;
            }
            else
                return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//检测碰撞当碰撞发生后重置canJump让物体重新能够有一次跳跃机会
    {
        if (collision.collider.tag == "EditorOnly")
            canJump = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float yPower = 400f;
    [SerializeField] string controllerButton = "Jump";
    //[SerializeField] float speed = 6.0f;//跳跃测试用水平速度
    Rigidbody2D rig;
    Vector2 vectorYPower;
    public bool isJump
    {
        get
        {
            return !canJump;
        }
    }//预留接口：用于判断是否跳跃来添加动画
    bool canJump;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        canJump = true;
        vectorYPower = new Vector2(0, yPower);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

        if (Input.GetButton(controllerButton) && canJump)//判断玩家有无输入A键，输入则跳跃
        {

            //canJump用来记录方块是否落地，初始为true,当发生碰撞被检测后被重置为true
            rig.AddForce(vectorYPower, ForceMode2D.Force);
            canJump = false;
        }
        else
            return;
    }

    private void OnCollisionEnter2D(Collision2D collision)//检测碰撞当碰撞发生后重置canJump让物体重新能够有一次跳跃机会
    {
        if (collision.collider.CompareTag("EditorOnly"))
            canJump = true;
        

    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EditorOnly"))
        {
            canJump = false;

        }
        
    }
}
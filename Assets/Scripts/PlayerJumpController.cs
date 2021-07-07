using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float ySpeed = 10f;
    [SerializeField] string controllerButton = "Jump";
    //[SerializeField] float speed = 6.0f;//��Ծ������ˮƽ�ٶ�
    Rigidbody2D rig;
    Vector2 vectorGravity;
    Vector2 vectorVelocity;
    [SerializeField] bool isJump;//Ԥ���ӿڣ������ж��Ƿ���Ծ����Ӷ���
    bool canJump;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        canJump = true;
        vectorGravity = new Vector2(0, 9.8f);
        isJump = false;
        vectorVelocity = new Vector2(0, ySpeed);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //��Ծ������ˮƽ�ƶ�
        /*Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;*/
        if (rig.velocity.y != 0)
            isJump = true;
        if (Input.GetButton(controllerButton) && canJump)//�ж������������A������������Ծ
        {

            //canJump������¼�����Ƿ���أ���ʼΪtrue,��������ײ����������Ϊtrue
            rig.velocity = vectorVelocity;
            //rig.AddForce(vectorYPower, ForceMode2D.Force);
            canJump = false;
        }
        else
            return;
    }

    private void OnCollisionEnter2D(Collision2D collision)//�����ײ����ײ����������canJump�����������ܹ���һ����Ծ����
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
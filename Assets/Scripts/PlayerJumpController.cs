using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float yPower = 400f;
    [SerializeField] string controllerButton = "Jump";
    //[SerializeField] float speed = 6.0f;//��Ծ������ˮƽ�ٶ�
    Rigidbody2D rig;
    Vector2 vectorYPower;
    public bool isJump
    {
        get
        {
            return !canJump;
        }
    }//Ԥ���ӿڣ������ж��Ƿ���Ծ����Ӷ���
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

        if (Input.GetButton(controllerButton) && canJump)//�ж������������A������������Ծ
        {

            //canJump������¼�����Ƿ���أ���ʼΪtrue,��������ײ����������Ϊtrue
            rig.AddForce(vectorYPower, ForceMode2D.Force);
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
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
        //��Ծ�������ƶ�
        /*Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;*/
        if (Input.GetButton(controllerButton))//�ж������������A������������Ծ
        {

            if (canJump == true)//canJump������¼�����Ƿ���أ���ʼΪtrue,��������ײ����������Ϊtrue
            {
                rig.AddForce(new Vector2(0,  yPower), ForceMode2D.Force);
                canJump = false;
            }
            else
                return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//�����ײ����ײ����������canJump�����������ܹ���һ����Ծ����
    {
        if (collision.collider.tag == "EditorOnly")
            canJump = true;

    }
}

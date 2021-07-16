using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectCollisionParticle : MonoBehaviour
{
    public ParticleSystem  whitePerfectCollision, blackPerfectCollision;
    public Transform myTransform;
    public GameObject whiteBlock,blackBlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pos = myTransform.position;
        float whiteX = whiteBlock.GetComponent<Rigidbody2D>().velocity.x;
        float whiteY = whiteBlock.GetComponent<Rigidbody2D>().velocity.y;
        float blackX = blackBlock.GetComponent<Rigidbody2D>().velocity.x;
        float blackY = blackBlock.GetComponent<Rigidbody2D>().velocity.y;

        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //�����˶����̻����ǰ��λ�Ʋ�ʲ���ֱ���ж��Ƿ���ȫ��ȣ�Bug13���µģ�
        if (collision.gameObject.CompareTag("White") && Mathf.Abs(blackX - whiteX) < 0.01)
        {
            //��������ת����λ��
            changePosition(pos);

            //������ײʱ����������Ч
            perfectParticle(whiteY, blackY);
        }
        else
        {
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();
        }
    }

    private void changePosition(Vector2 pos)
    {
        //��������ֱ�����ٶ�����
        ClearY(blackBlock.GetComponent<Rigidbody2D>());
        ClearY(whiteBlock.GetComponent<Rigidbody2D>());

        //����λ��
        pos = whiteBlock.transform.position;
        whiteBlock.transform.position = blackBlock.transform.position;
        blackBlock.transform.position = pos;
    }

    private void ClearY(Rigidbody2D body)
    {
        body.velocity = new Vector2(body.velocity.x, 0);
    }

    private void perfectParticle(float whiteY,float blackY)
    {
        //���Լ����򴥷�������ײʱ����������Ч����֮������
        if (blackY >= whiteY)
        {
            whitePerfectCollision.Play();
            blackPerfectCollision.Play();
        }
    }
}
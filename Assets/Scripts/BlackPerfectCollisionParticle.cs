using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPerfectCollisionParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem whitePerfectCollision, blackPerfectCollision;
    [SerializeField]
    private Rigidbody2D whiteBlock, blackBlock;
    private float halfScreen;

    private void Start()
    {
        halfScreen = (float)Screen.height / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float whiteY = whiteBlock.velocity.y;
        float blackY = blackBlock.velocity.y;

        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //�����˶����̻����ǰ��λ�Ʋ�ʲ���ֱ���ж��Ƿ���ȫ��ȣ�Bug13���µģ�
        //if (collision.gameObject.CompareTag("White") && Mathf.Abs((whiteY + blackY) / 2 - halfScreen) <= halfScreen * 0.01)
        if (collision.gameObject.CompareTag("White"))
        {
            //��������ת����λ��
            changePosition();

            //������ײʱ����������Ч
            perfectParticle(whiteY, blackY);
        }
        else
        {
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();
        }
    }

    private void changePosition()
    {

        //����λ��
        var pos = whiteBlock.transform.position;
        whiteBlock.transform.position = blackBlock.transform.position;
        blackBlock.transform.position = pos;
        //��������ֱ�����ٶ�����
        ClearY(blackBlock);
        ClearY(whiteBlock);

    }

    private void ClearY(Rigidbody2D body)
    {
        body.velocity = new Vector2(body.velocity.x, 0);
    }

    private void perfectParticle(float whiteY, float blackY)
    {
        //���Լ����򴥷�������ײʱ����������Ч����֮������
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }
}
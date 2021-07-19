///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-16
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-19
///</summary>


using UnityEngine;

public class PerfectCollisionParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem whitePerfectCollision, blackPerfectCollision;
    [SerializeField]
    private Rigidbody2D whiteBlock, blackBlock;
    [SerializeField]
    private Distance d1;
    [SerializeField]
    private Distance d2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //��������ת����λ��
            ChangePosition();

            //������ײʱ����������Ч
            PerfectParticle();

            //����Bonus״̬ʱ����¼��ǰ˫�������С,����bonus״̬Ϊtrue
            d1.StartBonus();
            d2.StartBonus();
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�˳�Bonus״̬ʱ���ٴμ�¼˫�������С,����bonus״̬Ϊfalse
        float whiteY = whiteBlock.velocity.y;
        float blackY = blackBlock.velocity.y;
        if (blackY < 0)
        {
            d1.EndBonus();
        }
        if (whiteY > 0)
        {
            d2.EndBonus();
        }

        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //ֹͣ����������ײ������Ч
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();
        }
    }

    private void ChangePosition()
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

    private void PerfectParticle()
    {
        //���Լ����򴥷�������ײʱ����������Ч����֮������
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }
}
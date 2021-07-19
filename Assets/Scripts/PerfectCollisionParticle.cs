using UnityEngine;

public class PerfectCollisionParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem whitePerfectCollision, blackPerfectCollision;
    [SerializeField]
    private Rigidbody2D whiteBlock, blackBlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //�����˶����̻����ǰ��λ�Ʋ�ʲ���ֱ���ж��Ƿ���ȫ��ȣ�Bug13���µģ�
        //if (collision.gameObject.CompareTag("White") && Mathf.Abs((whiteY + blackY) / 2 - halfScreen) <= halfScreen * 0.01)
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            float whiteY = whiteBlock.velocity.y;
            float blackY = blackBlock.velocity.y;

            //��������ת����λ��
            ChangePosition();

            //������ײʱ����������Ч
            PerfectParticle(whiteY, blackY);
        }
        else
        {
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

    private void PerfectParticle(float whiteY, float blackY)
    {
        //���Լ����򴥷�������ײʱ����������Ч����֮������
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }
}
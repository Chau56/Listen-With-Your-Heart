///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-16
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-21
///</summary>


using UnityEngine;

public class PerfectCollisionParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem whitePerfectCollision, blackPerfectCollision;
    [SerializeField]
    private Rigidbody2D whiteBlock, blackBlock;
    [SerializeField]
    private Distance BlackDistance;
    [SerializeField]
    private Distance WhiteDistance;

    [SerializeField]
    private GameObject BlackPlus;
    [SerializeField]
    private GameObject WhitePlus;
    [SerializeField]
    private GameObject BlackBonus;
    [SerializeField]
    private GameObject WhiteBonus;

    [SerializeField]
    private GameObject BlackOriginalTrail, BlackUpdatedTrail;
    [SerializeField]
    private GameObject WhiteOriginalTrail, WhiteUpdatedTrail;

    //private bool isCollide;
    private bool isDie;

    private void Start()
    {
        var events = GameEvents.instance;
        events.BlackWillDie += SetDeath;
        events.WhiteWillDie += SetDeath;
        events.GameBeforeAwake += ResetDeath;

        //��ʼʱ����Bonus
        BlackBonusDisappear();
        WhiteBonusDisappear();

        // ��ʼʱ��ʾԭ��β
        UpdatedTurnOriginalTrail();
    }

    private void Update()
    {
        blackBonusCalculate();
        whiteBonusCalculate();
    }

    private void SetDeath()
    {
        isDie = true;
    }

    private void ResetDeath()
    {
        isDie = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //��������ת����λ��
            ChangePosition();

            //������ײʱ����������Ч
            PerfectParticle();

            // ��ʾ����β���ڰ׷��ࣩ
            originalTurnUpdatedTrail();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //��ʾBonus��ֵ1s
            if (!WhiteDistance.bonus)
            {
                WhiteBonusAppear();
                Invoke("WhiteBonusDisappear", 1f);
            }

            if (!BlackDistance.bonus)
            {
                BlackBonusAppear();
                Invoke("BlackBonusDisappear", 1f);
            }

            //ֹͣ����������ײ������Ч
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();

            // ��ʾԭ��β
            UpdatedTurnOriginalTrail();
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

    //Bonus������ʾ
    private void BlackBonusAppear()
    {
        BlackPlus.SetActive(true);
        BlackBonus.SetActive(true);
    }
    private void WhiteBonusAppear()
    {
        WhitePlus.SetActive(true);
        WhiteBonus.SetActive(true);
    }

    //Bonus������ʧ
    private void BlackBonusDisappear()
    {
        BlackPlus.SetActive(false);
        BlackBonus.SetActive(false);
    }
    private void WhiteBonusDisappear()
    {
        WhitePlus.SetActive(false);
        WhiteBonus.SetActive(false);
    }

    //��β�л�
    private void originalTurnUpdatedTrail()
    {
        BlackOriginalTrail.SetActive(false);
        WhiteOriginalTrail.SetActive(false);
        BlackUpdatedTrail.SetActive(true);
        WhiteUpdatedTrail.SetActive(true);
    }
    private void UpdatedTurnOriginalTrail()
    {
        BlackUpdatedTrail.SetActive(false);
        WhiteUpdatedTrail.SetActive(false);
        BlackOriginalTrail.SetActive(true);
        WhiteOriginalTrail.SetActive(true);
    }

    //private void OnTriggerEnter2D(Collider2D collision)     //��ײ����
    //{
    //    //ÿ����ײ�ı�״̬
    //    if (collision.tag == "White")
    //    {
    //        isCollide = !isCollide;
    //    }
    //}

    private void whiteBonusCalculate()
    {
        //if (isCollide || whiteBlock.transform.position.y > 0)
        //����Bonus״̬ʱ����¼��ǰ�׿�����С,����bonus״̬Ϊtrue
        if (whiteBlock.transform.position.y > 0)
        {
            WhiteDistance.StartBonus();
        }
        //else if(!isCollide || isDie || whiteBlock.transform.position.y < 0)
        //�жϰ׿��Ƿ�ص��Լ��������������
        else if (isDie || whiteBlock.transform.position.y < 0)
        {
            WhiteDistance.EndBonus();
        }
    }

    private void blackBonusCalculate()
    {
        //����Bonus״̬ʱ����¼��ǰ�ڿ�����С,����bonus״̬Ϊtrue
        if (blackBlock.transform.position.y < 0)
        {
            BlackDistance.StartBonus();
        }
        //else if(!isCollide || isDie || whiteBlock.transform.position.y < 0)
        //�жϷ����Ƿ�ص��Լ��������������
        else if (isDie || blackBlock.transform.position.y > 0)
        {
            BlackDistance.EndBonus();
        }


    }
}
///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-16
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-22
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
    
    [SerializeField]
    private ParticleSystem whiteOriginalTrailParticle, blackOriginalTrailParticle;
    [SerializeField]
    private ParticleSystem whiteUpdatedTrailParticle, blackUpdatedTrailParticle;


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

        // ��ʼʱ��ʾԭ��β��������
        UpdatedTurnOriginalTrail();
        updatedTurnoriginalTrailParticle();

        ResetDeath();
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

            // ��ʾ����β����β���ӣ��ڰ׷��ࣩ
            originalTurnUpdatedTrail();
            originalTurnUpdatedTrailParticle();

            //��ʾBonus��ֵ1s
            bonusDisplay();
        }

        //����ʱֹͣ����������ײ������Ч����ʾԭ��β��������
        if (isDie)
        {
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();

            UpdatedTurnOriginalTrail();
            updatedTurnoriginalTrailParticle();

            ResetDeath();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //����ʱֹͣ����������ײ������Ч
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();

            // ��ʾԭ��β����β����
            UpdatedTurnOriginalTrail();
            updatedTurnoriginalTrailParticle();
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

    private void whiteBonusCalculate()
    {
        //����Bonus״̬ʱ����¼��ǰ�׿�����С,����bonus״̬Ϊtrue
        if (whiteBlock.transform.position.y > 0)
        {
            WhiteDistance.StartBonus();
        }

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

        //�жϺڿ��Ƿ�ص��Լ��������������
        else if (isDie || blackBlock.transform.position.y > 0)
        {
            BlackDistance.EndBonus();
        }
    }

    //Bonus����ʾ����ʧ
    private void bonusDisplay()
    {
        if (!WhiteDistance.bonus)
        {
            WhiteBonusAppear();
            Invoke("WhiteBonusDisappear", 1.2f);
        }

        if (!BlackDistance.bonus)
        {
            BlackBonusAppear();
            Invoke("BlackBonusDisappear", 1.2f);
        }
    }

    //��β�����л�
    private void originalTurnUpdatedTrailParticle()
    {
        blackUpdatedTrailParticle.Play();
        whiteUpdatedTrailParticle.Play();
        blackOriginalTrailParticle.Stop();
        whiteOriginalTrailParticle.Stop();
    }

    private void updatedTurnoriginalTrailParticle()
    {
        blackOriginalTrailParticle.Play();
        whiteOriginalTrailParticle.Play();
        blackUpdatedTrailParticle.Stop();
        whiteUpdatedTrailParticle.Stop();
    }
}
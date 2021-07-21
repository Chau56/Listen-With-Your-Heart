///<summary>
///作者：周澄鑫
///创建日期：2021-7-16
///更新者：周权
///最新修改日期：2021-7-21
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

        //开始时隐藏Bonus
        BlackBonusDisappear();
        WhiteBonusDisappear();

        // 开始时显示原拖尾
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
            //两方块旋转交换位置
            ChangePosition();

            //完美碰撞时触发粒子特效
            PerfectParticle();

            // 显示新拖尾（黑白反相）
            originalTurnUpdatedTrail();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            //显示Bonus数值1s
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

            //停止播放完美碰撞粒子特效
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();

            // 显示原拖尾
            UpdatedTurnOriginalTrail();
        }
    }

    private void ChangePosition()
    {
        //交换位置
        var pos = whiteBlock.transform.position;
        whiteBlock.transform.position = blackBlock.transform.position;
        blackBlock.transform.position = pos;

        //将方块竖直方向速度清零
        ClearY(blackBlock);
        ClearY(whiteBlock);
    }

    private void ClearY(Rigidbody2D body)
    {
        body.velocity = new Vector2(body.velocity.x, 0);
    }

    private void PerfectParticle()
    {
        //从自己区域触发完美碰撞时播放粒子特效，反之不触发
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }

    //Bonus分数显示
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

    //Bonus分数消失
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

    //拖尾切换
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

    //private void OnTriggerEnter2D(Collider2D collision)     //碰撞触发
    //{
    //    //每次碰撞改变状态
    //    if (collision.tag == "White")
    //    {
    //        isCollide = !isCollide;
    //    }
    //}

    private void whiteBonusCalculate()
    {
        //if (isCollide || whiteBlock.transform.position.y > 0)
        //进入Bonus状态时，记录当前白块距离大小,更改bonus状态为true
        if (whiteBlock.transform.position.y > 0)
        {
            WhiteDistance.StartBonus();
        }
        //else if(!isCollide || isDie || whiteBlock.transform.position.y < 0)
        //判断白块是否回到自己的区域或者死亡
        else if (isDie || whiteBlock.transform.position.y < 0)
        {
            WhiteDistance.EndBonus();
        }
    }

    private void blackBonusCalculate()
    {
        //进入Bonus状态时，记录当前黑块距离大小,更改bonus状态为true
        if (blackBlock.transform.position.y < 0)
        {
            BlackDistance.StartBonus();
        }
        //else if(!isCollide || isDie || whiteBlock.transform.position.y < 0)
        //判断方块是否回到自己的区域或者死亡
        else if (isDie || blackBlock.transform.position.y > 0)
        {
            BlackDistance.EndBonus();
        }


    }
}
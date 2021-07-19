///<summary>
///作者：周澄鑫
///创建日期：2021-7-16
///更新者：周权
///最新修改日期：2021-7-19
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
            //两方块旋转交换位置
            ChangePosition();

            //完美碰撞时触发粒子特效
            PerfectParticle();

            //进入Bonus状态时，记录当前双方距离大小,更改bonus状态为true
            d1.StartBonus();
            d2.StartBonus();
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //退出Bonus状态时，再次记录双方距离大小,更改bonus状态为false
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
            //停止播放完美碰撞粒子特效
            whitePerfectCollision.Stop();
            blackPerfectCollision.Stop();
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
}
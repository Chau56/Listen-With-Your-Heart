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
        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //由于运动过程会产生前后位移差，故不能直接判断是否完全相等（Bug13导致的）
        //if (collision.gameObject.CompareTag("White") && Mathf.Abs((whiteY + blackY) / 2 - halfScreen) <= halfScreen * 0.01)
        if (obj.CompareTag("White") || obj.CompareTag("Black"))
        {
            float whiteY = whiteBlock.velocity.y;
            float blackY = blackBlock.velocity.y;

            //两方块旋转交换位置
            ChangePosition();

            //完美碰撞时触发粒子特效
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

    private void PerfectParticle(float whiteY, float blackY)
    {
        //从自己区域触发完美碰撞时播放粒子特效，反之不触发
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }
}
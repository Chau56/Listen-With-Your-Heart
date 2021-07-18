///<summary>
///作者：周澄鑫
///创建日期：2021-7-15
///更新者：周权
///最新修改日期：2021-7-17
///</summary>


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

        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //由于运动过程会产生前后位移差，故不能直接判断是否完全相等（Bug13导致的）
        //if (collision.gameObject.CompareTag("White") && Mathf.Abs((whiteY + blackY) / 2 - halfScreen) <= halfScreen * 0.01)
        if (collision.gameObject.CompareTag("White"))
        {
            //两方块旋转交换位置
            changePosition();

            //完美碰撞时触发粒子特效
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

    private void perfectParticle(float whiteY, float blackY)
    {
        //从自己区域触发完美碰撞时播放粒子特效，反之不触发
        whitePerfectCollision.Play();
        blackPerfectCollision.Play();
    }
}

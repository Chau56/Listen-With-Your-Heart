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

        //if (collision.gameObject.CompareTag("White") && blackX == whiteX)         //由于运动过程会产生前后位移差，故不能直接判断是否完全相等（Bug13导致的）
        if (collision.gameObject.CompareTag("White") && Mathf.Abs(blackX - whiteX) < 0.01)
        {
            //两方块旋转交换位置
            changePosition(pos);

            //完美碰撞时触发粒子特效
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
        //将方块竖直方向速度清零
        ClearY(blackBlock.GetComponent<Rigidbody2D>());
        ClearY(whiteBlock.GetComponent<Rigidbody2D>());

        //交换位置
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
        //从自己区域触发完美碰撞时播放粒子特效，反之不触发
        if (blackY >= whiteY)
        {
            whitePerfectCollision.Play();
            blackPerfectCollision.Play();
        }
    }
}
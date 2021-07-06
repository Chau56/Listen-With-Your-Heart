using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] public static float speed = 5f;      //物体移动速度

    // Update is called once per frame
    void Update()
    {
        //遍历背景，获取子物体（方块A和B）
        foreach (Transform tran in transform)           //tran是Background层下的所有子物体
        {
            //获取子物体的位置
            Vector3 pos = tran.position;

            //按照速度向右侧移动
            pos.x += speed * Time.deltaTime;

            //位置赋给子物体
            tran.position = pos;
        }
    }
}

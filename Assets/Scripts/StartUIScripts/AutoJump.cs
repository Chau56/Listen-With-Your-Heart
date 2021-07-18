///<summary>
///作者：张子龙
///创建日期：2021-7-14
///更新者：周权
///最新修改日期：2021-7-14
///</summary>


using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class AutoJump : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("随机跳跃概率")]
    private float randomProbability = 0.01f;//随即跳跃概率
    [SerializeField]
    [Tooltip("随机跳跃时间，单位毫秒")]
    private int randomTime = 1000;//随即跳跃概率

    private void Start()
    {
        events = GameEvents.instance;
    }

    private void FixedUpdate()
    {
        if (Random.value < randomProbability)
        {
            events.StartJump1();
            _ = FinishJump(events.FinishJump1);
        }
        if (Random.value < randomProbability)
        {
            events.StartJump2();
            _ = FinishJump(events.FinishJump2);
        }
    }

    private async Task FinishJump(Func<bool> func)
    {
        await Task.Delay(randomTime);
        func();
    }
}


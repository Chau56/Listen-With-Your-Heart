using System;
using UnityEngine;

public abstract class SwitchBehavior : MonoBehaviour
{
    [SerializeField]
    protected GameEvents events;
    [SerializeField]
    [Tooltip("这是哪个玩家？")]
    protected PlayerEnum player;

    protected void Swicher(Action black, Action white)
    {
        switch (player)
        {
            case PlayerEnum.Black:
                black();
                break;
            case PlayerEnum.White:
                white();
                break;
        }
    }

}

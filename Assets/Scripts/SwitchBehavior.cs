using System;
using UnityEngine;

public abstract class SwitchBehavior : MonoBehaviour
{
    protected GameEvents events;
    [SerializeField]
    [Tooltip("这是哪个玩家？")]
    protected PlayerEnum player;

    protected SwitchBehavior()
    {
        events = GameEvents.instance;
    }

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

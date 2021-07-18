///<summary>
///作者：张子龙
///创建日期：2021-7-8
///更新者：周权
///最新修改日期：2021-7-8
///</summary>

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorLogic : MonoBehaviour
{
    private Animator animator;
    private GameEvents events;

    private void Start()
    {
        events = GameEvents.instance;
        animator = GetComponent<Animator>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameBeforeAwake += Fadein;
        events.GameFailed += FadeOut;
        events.GameAbnormalEnd += FadeOut;
    }

    private void Fadein()
    {
        animator.SetBool("GameEnd", false);
    }

    private void FadeOut()
    {
        animator.SetBool("GameEnd", true);
    }
}

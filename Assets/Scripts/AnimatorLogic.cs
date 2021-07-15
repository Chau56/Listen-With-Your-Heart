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
        events.GameAwake += Fadein;
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
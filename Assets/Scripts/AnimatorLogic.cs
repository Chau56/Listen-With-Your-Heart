using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("״̬�����Ӧ��������")]
    private string gameStart = "GameStart";
    [SerializeField]
    [Tooltip("״̬�����Ӧ��������")]
    private string gameFailed = "GameFailed";
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
        animator.SetTrigger(gameStart);
    }

    private void FadeOut()
    {
        animator.SetTrigger(gameFailed);
    }
}
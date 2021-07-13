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
        events.GameFailed += FadeOut;
        events.GameAbnormalEnd += FadeOut;
        animator.SetTrigger(gameStart);
    }

    private void FadeOut()
    {
        animator.SetTrigger(gameFailed);
    }
}
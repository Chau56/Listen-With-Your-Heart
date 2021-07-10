using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class AnimatorLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("状态机里对应触发器名")]
    private string gameStart = "GameStart";
    [SerializeField]
    [Tooltip("状态机里对应触发器名")]
    private string gameFailed = "GameFailed";
    private Animator animator;
    [SerializeField]
    private GameEvents events;

    private void Start()
    {
        animator = GetComponent<Animator>();
        events.GameFailed += FadeOut;
        animator.SetTrigger(gameStart);
    }

    private void FadeOut()
    {
        animator.SetTrigger(gameFailed);
    }
}
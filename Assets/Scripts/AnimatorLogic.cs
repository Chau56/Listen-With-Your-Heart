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
    [SerializeField]
    [Tooltip("多久后加载新场景")]
    private float waitTime = 1;
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
        StartCoroutine(WaitForAnimation());
    }
    private IEnumerator WaitForAnimation()
    {
        Debug.Log("start wait for animation");
        yield return new WaitForSecondsRealtime(waitTime);
        Debug.Log("animation finished. will load scene.");
        SceneManager.LoadScene(0);
    }
}
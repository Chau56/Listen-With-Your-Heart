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
    //[SerializeField]
    //[Tooltip("放置重生粒子特效的预制件")]
    //private Object ParticleEffects;
    //[SerializeField]
    //[Tooltip("放置黑块")]
    //private GameObject BlackCube;
    //[SerializeField]
    //[Tooltip("放置白块")]
    //private GameObject WhiteCube;
    private Animator animator;
    [SerializeField]
    private GameEvents events;

    private void Start()
    {
        animator = GetComponent<Animator>();
        events.GameEnd += FadeOut;
        animator.SetTrigger(gameStart);
        //Instantiate(ParticleEffects, BlackCube.transform);
        //Instantiate(ParticleEffects, WhiteCube.transform);

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
    /// 用于动画结束后事件的调用，重新加载场景，现在已被移动至GameEvents

}
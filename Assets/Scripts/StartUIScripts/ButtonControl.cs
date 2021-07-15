using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class ButtonControl : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    [Tooltip("延迟转场。单位毫秒")]
    private int delay = 1000;
    [SerializeField]
    private RevivePositionReset reset;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //button1 = GameObject.Find("Start");
        //button2 = GameObject.Find("Exit");

    }

    //private void DelayButtonFalse()//使按钮在动画播放中消失
    //{

    //    button1.SetActive(false);
    //    button2.SetActive(false);
    //}

    public void SwitchScene()//开始游戏按钮调用的方法
    {
        animator.SetBool("GameEnd", true);
        Debug.Log("切换场景已执行");
        _ = LoadNextSceneAsync();
    }
    private async Task LoadNextSceneAsync()//异步加载场景1等待动画播放完后激活场景
    {
        reset.Source.Cancel();
        await Task.Delay(delay);
        var events = GameEvents.instance;
        events.ClearEvents();
        events.ClearState();
        SceneManager.LoadScene(1);
        //async.allowSceneActivation = false;

        //while (!async.isDone)
        //{
        //    GetAnimatorState = animator.GetCurrentAnimatorStateInfo(0);

        //    if (GetAnimatorState.normalizedTime >= 1.0f && GetAnimatorState.IsName("FadeOut"))
        //        async.allowSceneActivation = true;

        //    yield return null;
        //}
    }
    public void ExitGame()//退出游戏按钮调用的方法
    {
        Debug.Log("游戏退出已执行");
        Application.Quit();
    }
}
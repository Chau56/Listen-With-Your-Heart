using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl : MonoBehaviour
{
    private Animator Animator;
    private AnimatorStateInfo GetAnimatorState;
    private GameObject button1, button2;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        button1 = GameObject.Find("Start");
        button2 = GameObject.Find("Exit");

    }

    void DelayButtonFalse()//使按钮在动画播放中消失
    {

        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void SwitchScene()//开始游戏按钮调用的方法
    {
        Animator.Play("Base Layer.FadeOut");
        Debug.Log("切换场景已执行");
        StartCoroutine(LoadNextSceneAsync());
        Invoke("DelayButtonFalse", 0.1f);


    }
    private IEnumerator LoadNextSceneAsync()//异步加载场景1等待动画播放完后激活场景
    {
        var events = GameEvents.instance;
        events.ClearEvents();
        events.ClearState();
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            GetAnimatorState = Animator.GetCurrentAnimatorStateInfo(0);

            if (GetAnimatorState.normalizedTime >= 1.0f && GetAnimatorState.IsName("FadeOut"))
                async.allowSceneActivation = true;

            yield return null;
        }
    }
    public void ExitGame()//退出游戏按钮调用的方法
    {
        Debug.Log("游戏退出已执行");
        Application.Quit();
    }
}
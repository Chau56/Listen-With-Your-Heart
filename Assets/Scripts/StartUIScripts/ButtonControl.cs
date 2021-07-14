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

    void DelayButtonFalse()//ʹ��ť�ڶ�����������ʧ
    {

        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void SwitchScene()//��ʼ��Ϸ��ť���õķ���
    {
        Animator.Play("Base Layer.FadeOut");
        Debug.Log("�л�������ִ��");
        StartCoroutine(LoadNextSceneAsync());
        Invoke("DelayButtonFalse", 0.1f);


    }
    private IEnumerator LoadNextSceneAsync()//�첽���س���1�ȴ�����������󼤻��
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
    public void ExitGame()//�˳���Ϸ��ť���õķ���
    {
        Debug.Log("��Ϸ�˳���ִ��");
        Application.Quit();
    }
}
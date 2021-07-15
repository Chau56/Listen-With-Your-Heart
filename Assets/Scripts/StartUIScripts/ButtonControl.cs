using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class ButtonControl : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    [Tooltip("�ӳ�ת������λ����")]
    private int delay = 1000;
    [SerializeField]
    private RevivePositionReset reset;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //button1 = GameObject.Find("Start");
        //button2 = GameObject.Find("Exit");

    }

    //private void DelayButtonFalse()//ʹ��ť�ڶ�����������ʧ
    //{

    //    button1.SetActive(false);
    //    button2.SetActive(false);
    //}

    public void SwitchScene()//��ʼ��Ϸ��ť���õķ���
    {
        animator.SetBool("GameEnd", true);
        Debug.Log("�л�������ִ��");
        _ = LoadNextSceneAsync();
    }
    private async Task LoadNextSceneAsync()//�첽���س���1�ȴ�����������󼤻��
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
    public void ExitGame()//�˳���Ϸ��ť���õķ���
    {
        Debug.Log("��Ϸ�˳���ִ��");
        Application.Quit();
    }
}
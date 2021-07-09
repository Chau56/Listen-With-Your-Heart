using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class AnimatorLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("״̬�����Ӧ��������")]
    private string gameStart = "GameStart";
    [SerializeField]
    [Tooltip("״̬�����Ӧ��������")]
    private string gameFailed = "GameFailed";
    [SerializeField]
    [Tooltip("��ú�����³���")]
    private float waitTime = 1;
    //[SerializeField]
    //[Tooltip("��������������Ч��Ԥ�Ƽ�")]
    //private Object ParticleEffects;
    //[SerializeField]
    //[Tooltip("���úڿ�")]
    //private GameObject BlackCube;
    //[SerializeField]
    //[Tooltip("���ð׿�")]
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
    /// ���ڶ����������¼��ĵ��ã����¼��س����������ѱ��ƶ���GameEvents

}
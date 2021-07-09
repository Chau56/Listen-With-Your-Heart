using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class LevelRestartLogic : MonoBehaviour
{
    //��ȡ�ڿ�Ͱ׿�������ж�
    [SerializeField]
    [Tooltip("��ק�ڿ����˿�")]
    private DeathLogic blackLogic;
    [SerializeField]
    [Tooltip("��ק�׿����˿�")]
    private DeathLogic whiteLogic;
    //[SerializeField]
    //[Tooltip("��������������Ч��Ԥ�Ƽ�")]
    //private Object ParticleEffects;
    //[SerializeField]
    //[Tooltip("���úڿ�")]
    //private GameObject BlackCube;
    //[SerializeField]
    //[Tooltip("���ð׿�")]
    //private GameObject WhiteCube;
    private Animator Animator;
    private bool blackDead = false;
    private bool whiteDead = false;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        blackLogic.OnDied += () => blackDead = true;//����OnDead,�¼�������ڷ�������
        whiteLogic.OnDied += () => whiteDead = true;//ͬ�ϰ׷�������
        Animator.Play("Base Layer.FadeIn");//������ʼ����ʱ�򲥷ŵ��붯��
        //Instantiate(ParticleEffects, BlackCube.transform);
        //Instantiate(ParticleEffects, WhiteCube.transform);

    }

    private void Update()
    {
        if (blackDead && whiteDead)
        {
            Animator.Play("Base Layer.FadeOut");//�������鶼����ʱ�򲥷ŵ�������
            blackDead = false;
            whiteDead = false;

        }
    }
    /// <summary>
    /// ���ڶ����������¼��ĵ��ã����¼��س���
    /// </summary>
    public void LevelRestart()
    {
        SceneManager.LoadScene(0);
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class LevelRestartLogic : MonoBehaviour
{
    //获取黑块和白块的死亡判断
    [SerializeField]
    [Tooltip("拖拽黑块放入此框")]
    private DeathLogic blackLogic;
    [SerializeField]
    [Tooltip("拖拽白块放入此框")]
    private DeathLogic whiteLogic;
    //[SerializeField]
    //[Tooltip("放置重生粒子特效的预制件")]
    //private Object ParticleEffects;
    //[SerializeField]
    //[Tooltip("放置黑块")]
    //private GameObject BlackCube;
    //[SerializeField]
    //[Tooltip("放置白块")]
    //private GameObject WhiteCube;
    private Animator Animator;
    private bool blackDead = false;
    private bool whiteDead = false;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        blackLogic.OnDied += () => blackDead = true;//监听OnDead,事件触发后黑方块死亡
        whiteLogic.OnDied += () => whiteDead = true;//同上白方块死亡
        Animator.Play("Base Layer.FadeIn");//场景初始化的时候播放淡入动画
        //Instantiate(ParticleEffects, BlackCube.transform);
        //Instantiate(ParticleEffects, WhiteCube.transform);

    }

    private void Update()
    {
        if (blackDead && whiteDead)
        {
            Animator.Play("Base Layer.FadeOut");//两个方块都死的时候播放淡出动画
            blackDead = false;
            whiteDead = false;

        }
    }
    /// <summary>
    /// 用于动画结束后事件的调用，重新加载场景
    /// </summary>
    public void LevelRestart()
    {
        SceneManager.LoadScene(0);
    }

}
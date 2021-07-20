using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteAnim : MonoBehaviour
{
    private AnimatorStateInfo info;
    private Animator animator;
    public bool animFinished=false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LevelComplete()
    {
        animator.Play("Base Layer.LevelComplete", 0, 0);
        
    }
    public void BonusAutoEnlarge() 
    {
        animator.Play("Base Layer.BlackBonusAutoEnlarge",0,0);
        animator.Play("Base Layer.WhiteBonusAutoEnlarge",0,0);
    }

    public void ReviveNumShowup()
    {
        animator.Play("Base Layer.ReviveNumShowup", 0, 0);
        
    }
    public void BonusDistanceTransPlay()
    {
        animator.Play("Base Layer.BlackBonusTrans", 0, 0);
        animator.Play("Base Layer.WhiteBonusTrans", 0, 0);
        animator.Play("Base Layer.BlackDistanceTrans", 0, 0);
        animator.Play("Base Layer.WhiteDistanceTrans", 0, 0);

    }
   
    public void BScoreTrans()
    {
        animator.Play("Base Layer.BlackScoreTrans");
        animator.Play("Base Layer.WhiteScoreTrans");

    }
   
    private void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1.0f)
        {
            animFinished = true;
        }
    }
}

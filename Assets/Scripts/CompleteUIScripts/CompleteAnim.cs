using UnityEngine;

public class CompleteAnim : MonoBehaviour
{
  
    [SerializeField]
    private Animator blackComplete;
    [SerializeField]
    private Animator whiteComplete;
    [SerializeField]
    private Animator blackRevive;
    [SerializeField]
    private Animator whiteRevive;
    [SerializeField]
    private Animator blackRevived;
    [SerializeField]
    private Animator whiteRevived;
    [SerializeField]
    private Animator bBonus;
    [SerializeField]
    private Animator wBonus;
    [SerializeField]
    private Animator bDistanceTrans;
    [SerializeField]
    private Animator wDistanceTrans;
    [SerializeField]
    private Animator bSorce;
    [SerializeField]
    private Animator wSorce;



    public void ResetAnim()
    {
        blackComplete.Play("Base Layer.Complete0", 0, 0);
        whiteComplete.Play("Base Layer.Complete0", 0, 0);
       
        bBonus.Play("Base Layer.BlackBonusInitialState",0,0);
        wBonus.Play("Base Layer.WhiteBonusInitialState",0,0);
        
        blackRevive.Play("Base Layer.Blank", 0, 0);
        blackRevived.Play("Base Layer.Blank", 0, 0);
        whiteRevive.Play("Base Layer.Blank", 0, 0);
        whiteRevived.Play("Base Layer.Blank", 0, 0);

        
        bDistanceTrans.Play("Base Layer.InitialState", 0, 0);
        wDistanceTrans.Play("Base Layer.InitialState", 0, 0);

        bSorce.Play("Base Layer.ScoreInitialState");
        wSorce.Play("Base Layer.ScoreInitialState");
    }

    public void LevelComplete(bool isBlack)
    {
        if(isBlack)
        blackComplete.Play("Base Layer.LevelComplete", 0, 0);
        else
        whiteComplete.Play("Base Layer.LevelComplete", 0, 0);

    }

   
    public void BonusAutoEnlarge(bool isblack)
    {
        if (isblack)
        {
            bBonus.Play("Base Layer.BlackBonusAutoEnlarge", 0, 0);
        }
        else
        {
            wBonus.Play("Base Layer.WhiteBonusAutoEnlarge", 0, 0);
        }
    }

    
    public void ReviveNumShowup()
    {
        blackRevive.Play("Base Layer.ReviveNumShowup", 0, 0);
        blackRevived.Play("Base Layer.ReviveNumShowup", 0, 0);
        whiteRevive.Play("Base Layer.ReviveNumShowup", 0, 0);
        whiteRevived.Play("Base Layer.ReviveNumShowup", 0, 0);

    }
    public void BonusDistanceTransPlay()
    {
        bBonus.Play("Base Layer.BlackBonusTrans", 0, 0);
        wBonus.Play("Base Layer.WhiteBonusTrans", 0, 0);
        bDistanceTrans.Play("Base Layer.BlackDistanceTrans", 0, 0);
        wDistanceTrans.Play("Base Layer.WhiteDistanceTrans", 0, 0);

    }

    public void ScoreTrans(bool boolindex)
    {
        Debug.Log("¶¯»­ÒÑÖ´ÐÐ");
        if (boolindex)
        {
            bSorce.Play("Base Layer.BlackScoreTrans");
        }
        else
        {
            wSorce.Play("Base Layer.WhiteScoreTrans"); 
        }
        
    }
    
        
   

}

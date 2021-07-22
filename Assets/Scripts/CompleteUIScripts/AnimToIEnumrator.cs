using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToIEnumrator : MonoBehaviour
{
    [SerializeField]
    private EndUIDistance blackEndDistance;
    [SerializeField]
    private EndUIDistance whiteEndDistance;
    [SerializeField]
    private GetScore getBlackScore;
    [SerializeField]
    private GetScore getWhiteScore;
    [SerializeField]
    private EndUIDistanceNoAnim blackDistanceNoAnim;
    [SerializeField]
    private EndUIDistanceNoAnim whiteDistanceNoAnim;
    [SerializeField]
    private GetScore blackTotalScoreCopy;
    [SerializeField]
    private GetScore whiteTotalScoreCopy;
    private void playDistanceEnum() 
    {
        blackEndDistance.playDistanceCrement();
        whiteEndDistance.playDistanceCrement();
        blackDistanceNoAnim.playDistanceCrement();
        whiteDistanceNoAnim.playDistanceCrement();
    }

    private void playSingleScoreEnum()  
    {
        getBlackScore.playBlackScore();
        getWhiteScore.playWhiteScore();
        blackTotalScoreCopy.playBlackScore();
        whiteTotalScoreCopy.playWhiteScore();
    }

    private void playBlackTotalScoreEnum() 
    {
        blackTotalScoreCopy.playBlackTotalScore();
        
    }
    private void playWhiteTotalScoreEnum() 
    {
        whiteTotalScoreCopy.playWhiteTotalScore();
    }
}

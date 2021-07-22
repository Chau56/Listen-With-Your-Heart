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
    private void playDistanceEnum() 
    {
        blackEndDistance.playDistanceCrement();
        whiteEndDistance.playDistanceCrement();
    }

    private void playSingleScoreEnum()  
    {
        getBlackScore.playBlackScore();
        getWhiteScore.playWhiteScore();
    }

    private void playBlackTotalScoreEnum() 
    {
        getBlackScore.playBlackTotalScore();
        
    }
    private void playWhiteTotalScoreEnum() 
    {
        getWhiteScore.playWhiteTotalScore();
    }
}

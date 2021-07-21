using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndGameManager : MonoBehaviour
{  
    [Header("通关进度条")]
    [SerializeField]
    private Slider whiteSlider;
    [SerializeField]
    private Slider blackSlider;
    [Header("进度")]
    [SerializeField]
    private ProgressCalculate black;
    [SerializeField]
    private ProgressCalculate white;
    public int maxValue;
    public int minValue;
    private int changeTimes;
  
    public IEnumerator BlackCrement()
    {
        maxValue = black.Percent;  //一为黑色进度条
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for(int i = 0; i < changeTimes; i++)
        {
            result ++;
            blackSlider.value = result;
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(BlackCrement());
    }

    public IEnumerator WhiteCrement()
    {
        maxValue = white.Percent;  //一为黑色进度条
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for (int i = 0; i < changeTimes; i++)
        {
            result ++;
            whiteSlider.value = result;
            yield return new WaitForSeconds(0.01f);   
        }
        StopCoroutine(WhiteCrement());
    }

}

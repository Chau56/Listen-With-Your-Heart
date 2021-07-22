using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndUISlider : MonoBehaviour
{
    [Header("通关进度条")]
    [SerializeField]
    private Slider completeSlider;

    [Header("进度")]
    [SerializeField]
    private ProgressCalculate progress;

    [Header("文本")]
    [SerializeField]
    private Text Percent;

    [SerializeField]
    private CompleteAnim completeAnim;

    [SerializeField]
    private bool isBlack = true;
    private int maxValue;
    private int minValue;
    private int changeTimes;
    private GameEvents events;
    private void Start()
    {
        events = GameEvents.instance;
        events.GameEnd += () => StartCoroutine(SliderCrement());
        events.GameStart += () => completeAnim.ResetAnim();
    }

    private IEnumerator SliderCrement()
    {
        maxValue = progress.Percent;  //一为黑色进度条
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for (int i = 0; i < changeTimes; i++)
        {
            result++;
            completeSlider.value = result;
            Percent.text = $"{result}+%";
            yield return new WaitForSeconds(0.01f);
        }
        completeSlider.value = maxValue;
        Percent.text = $"{maxValue}+%";
        completeAnim.LevelComplete(isBlack);
    }



}
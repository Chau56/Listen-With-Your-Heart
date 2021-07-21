using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndUISlider : MonoBehaviour
{
    [Header("ͨ�ؽ�����")]
    [SerializeField]
    private Slider completeSlider;
   
    [Header("����")]
    [SerializeField]
    private ProgressCalculate progress;
   
    [Header("�ı�")]
    [SerializeField]
    private Text Percent;

    private int maxValue;
    private int minValue;
    private int changeTimes;
    private void Start()
    {
        GameEvents.instance.GameWin += rerun;
    }
    private void rerun()
    {
        StartCoroutine(SliderCrement());

    }
    public IEnumerator SliderCrement()
    {
        maxValue = progress.Percent;  //һΪ��ɫ������
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
        StopCoroutine(SliderCrement());
    }

    

}
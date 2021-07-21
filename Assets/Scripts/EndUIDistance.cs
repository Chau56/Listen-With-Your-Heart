using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndUIDistance : MonoBehaviour
{
    [SerializeField]
    private Distance blackDistance;
    [SerializeField]
    private Distance whiteDistance;
    [SerializeField]
    private Text black;
    [SerializeField]
    private Text white;
    int maxValue;
    int minValue;
    int changeTimes;

    public IEnumerator BlackDistanceCrement()
    {
        maxValue = blackDistance.Value;
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for(int i = 0; i < changeTimes; i++)
        {
            result ++;
            black.text = result.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        black.text = maxValue.ToString();
        StopCoroutine(BlackDistanceCrement());
    }
    public IEnumerator WhiteDistanceCrement()
    {
        maxValue = whiteDistance.Value;
        minValue = 0;
        int result = minValue;
        changeTimes = maxValue; 
        for (int j = 0; j < changeTimes; j++)
        {
            result ++;
            white.text = result.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        white.text = maxValue.ToString();
        StopCoroutine(WhiteDistanceCrement());
    }

}

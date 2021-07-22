using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIDistanceNoAnim : MonoBehaviour
{
    [SerializeField]
    private Distance Distance;

    [SerializeField]
    private Text RoleDistance;

    private int maxValue;
    private int minValue;
    private int changeTimes;

    public void playDistanceCrement()
    {
        StartCoroutine(DistanceCrement());

    }
    private IEnumerator DistanceCrement()
    {
        maxValue = Distance.Value;
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for (int i = 0; i < changeTimes; i++)
        {
            result++;
            RoleDistance.text = result.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        RoleDistance.text = maxValue.ToString();
    }

}
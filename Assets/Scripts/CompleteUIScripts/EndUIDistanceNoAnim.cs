///<summary>
///作者：张翔宇
///创建日期：2021-7-20
///最新修改日期：2021-7-23
///</summary>


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
    private GameEvents events;

    private void Start()
    {
        events = GameEvents.instance;
        events.GameStart += () => RoleDistance.text =$"0" ;
    }

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
        for (int i = 0; i < changeTimes; i+=3)
        {
            result+=3;
            RoleDistance.text = result.ToString();
            yield return new WaitForSeconds(0.002f);
        }
        RoleDistance.text = maxValue.ToString();
    }

}

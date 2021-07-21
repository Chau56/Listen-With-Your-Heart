using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndUIDistance : MonoBehaviour
{
    [SerializeField]
    private Distance Distance;
 
    [SerializeField]
    private Text RoleDistance;

    private int maxValue;
    private int minValue;
    private int changeTimes;
    private void Start()
    {
        RegisterEvents();
    }
    void RegisterEvents()
    {
        var events = GameEvents.instance;
        events.GameWin += run;
    }
    void run()
    {
        StartCoroutine(DistanceCrement());
        
    }
    public IEnumerator DistanceCrement()
    {
        maxValue = Distance.Value;
        minValue = 0;
        changeTimes = maxValue;
        int result = minValue;
        for(int i = 0; i < changeTimes; i++)
        {
            result ++;
            RoleDistance.text = result.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        RoleDistance.text = maxValue.ToString();
        StopCoroutine(DistanceCrement());
    }  

}

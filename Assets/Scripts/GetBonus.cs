///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetBonus : MonoBehaviour
{
    private Text text;
    [SerializeField]
    private Distance distance;
    private int maxValue;
    private int minValue;
    private int Times;
    private void Start()
    {
        text = GetComponent<Text>();
        GameEvents.instance.GameWin += Renew;
        
    }
    private void Renew()
    {
       
    }
    public IEnumerator Bonus()
    {
        maxValue = distance.Bonus;
        minValue = 0;
        Times = distance.Bonus;
        int result  = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            text.text = $"+{result}";
            yield return new WaitForSeconds(0.01f);
        }
        text.text = $"+{maxValue}";
        StopCoroutine(Bonus());
    }
   
}

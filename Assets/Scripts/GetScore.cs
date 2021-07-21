///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetScore : MonoBehaviour
{
    private Text text;
    [SerializeField]
    private Distance d1;
    [SerializeField]
    private Distance d2;
    int maxValue;
    int minValue;
    int Times;
    private void Start()
    {
        text = GetComponent<Text>();
        GameEvents.instance.GameWin += Renew;
    }

    private void Renew()
    {  
       
    }
    public IEnumerator BlackScore()
    {
        maxValue = d1.Value+d1.Bonus;
        minValue = 0;
        Times = maxValue;
        int result  = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            text.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        text.text = $"{maxValue}";
        StopCoroutine(BlackScore());
    }
    public IEnumerator WhiteScore()
    {
        maxValue = d2.Value + d2.Bonus;
        minValue = 0;
        Times = maxValue;
        int result  = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            text.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        text.text = $"{maxValue}";
        StopCoroutine(WhiteScore());
    }
    public IEnumerator TotalScore()
    {
        maxValue = d2.Value+d1.Bonus+d2.Value + d2.Bonus;
        minValue = d1.Value+d1.Bonus;
        Times = maxValue ;
        int result  = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            text.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        text.text = $"{maxValue}";
        StopCoroutine(TotalScore());
    }
}

///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetScore : MonoBehaviour
{ 
    [SerializeField]
    private Text blackText;
    [SerializeField]
    private Text whiteText;
    [SerializeField]
    private Distance d1;
    [SerializeField]
    private Distance d2;
    
    private int maxValue;
    private int minValue;
    private int Times;
    private void Start()
    {
        
        GameEvents.instance.GameWin += Renew;
    }

    private void Renew()
    {
        Parallel.Invoke(() =>StartCoroutine(BlackScore()), () => StartCoroutine(WhiteScore()));
        Parallel.Invoke(() => StartCoroutine(BlackTotalScore()), () => StartCoroutine(WhiteTotalScore()));
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
            blackText.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        blackText.text = $"{maxValue}";
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
            whiteText.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        whiteText.text = $"{maxValue}";
        StopCoroutine(WhiteScore());
    }
    public IEnumerator BlackTotalScore()
    {
        maxValue = d2.Value+d1.Bonus+d2.Value + d2.Bonus;
        minValue = d1.Value+d1.Bonus;
        Times = maxValue ;
        int result  = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            blackText.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        blackText.text = $"{maxValue}";
        StopCoroutine(BlackTotalScore());
    }
    public IEnumerator WhiteTotalScore()
    {
        maxValue = d2.Value + d1.Bonus + d2.Value + d2.Bonus;
        minValue = d2.Value + d2.Bonus;
        Times = maxValue;
        int result = minValue;
        for (int i = 0; i < Times; i++)
        {
            result++;
            whiteText.text = $"{result}";
            yield return new WaitForSeconds(0.01f);
        }
        whiteText.text = $"{maxValue}";
        StopCoroutine(WhiteTotalScore());
    }
}

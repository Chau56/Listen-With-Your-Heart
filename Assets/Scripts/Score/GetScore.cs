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
    [SerializeField]
    private CompleteAnim completeAnim;
    private GameEvents events;

    private void Start()
    {
        events = GameEvents.instance;
        events.GameStart += ResetScore;
    }

    private void ResetScore() 
    {
        blackText.text = $"0";
        whiteText.text = $"0";
    }

    public void playBlackScore()
    {
        blackText.text = $"{2 * d1.Value - d1.Bonus}";
        completeAnim.ScoreTrans(true);
    }

   

    public void playWhiteScore()
    {
        whiteText.text = $"{2 * d2.Value - d2.Bonus}";
        completeAnim.ScoreTrans(false);
    }

  

    public void playBlackTotalScore()
    {
        blackText.text = $"{2 * d1.Value - d1.Bonus + 2 * d2.Value - d2.Bonus}";
    }

   

    public void playWhiteTotalScore()
    {
        whiteText.text = $"{2 * d1.Value - d1.Bonus + 2 * d2.Value - d2.Bonus}";
    }

   
}

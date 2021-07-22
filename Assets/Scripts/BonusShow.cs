///<summary>
///作者：周澄鑫
///创建日期：2021-7-19
///更新者：周权
///最新修改日期：2021-7-22
///</summary>


using UnityEngine;
using UnityEngine.UI;

public class BonusShow : MonoBehaviour
{
    [SerializeField]
    private Distance dist;
    private Text BonusScore;

    private void Start()
    {
        BonusScore = GetComponent<Text>();
    }

    void Update()
    {
        if (dist.bonus)
        {
            bonusScoreShow();
        }
    }

    // 显示每次Bonus的数值
    public void bonusScoreShow()
    {
        BonusScore.text = dist.eachBonus.ToString();
    }

}

///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-19
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-22
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

    // ��ʾÿ��Bonus����ֵ
    public void bonusScoreShow()
    {
        BonusScore.text = dist.eachBonus.ToString();
    }

}

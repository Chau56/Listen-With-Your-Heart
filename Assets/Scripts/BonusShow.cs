///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-19
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-20
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
        //BonusScore.text = dist.Bonus.ToString();
        // ��ʾÿ��Bonus����ֵ
        BonusScore.text = dist.eachBonus.ToString();
    }

}

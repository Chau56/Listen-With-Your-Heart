///<summary>
///���ߣ��ܳ���
///�������ڣ�2021-7-19
///�����ߣ���Ȩ
///�����޸����ڣ�2021-7-19
///</summary>


using System.Collections;
using System.Collections.Generic;
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
        BonusScore.text = dist.Bonus.ToString();
    }

}

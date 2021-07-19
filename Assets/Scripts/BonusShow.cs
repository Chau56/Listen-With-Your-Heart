///<summary>
///作者：周澄鑫
///创建日期：2021-7-19
///更新者：周权
///最新修改日期：2021-7-19
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

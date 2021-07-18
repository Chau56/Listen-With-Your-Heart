///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>


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

    private void Start()
    {
        text = GetComponent<Text>();
        GameEvents.instance.GameWin += Renew;
    }

    private void Renew()
    {
        text.text = d1.Value + d1.Bonus + d2.Value + d2.Bonus + "";
    }

}

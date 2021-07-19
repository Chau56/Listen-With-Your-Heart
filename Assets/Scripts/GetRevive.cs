///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetRevive : SwitchBehavior
{
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        events.GameWin += Renew;
    }

    private void Renew()
    {
        Swicher(() =>
        {
            text.text = events.BlackRevive.ToString();
        }, () =>
         {
             text.text = events.WhiteRevive.ToString();
         });
    }
}

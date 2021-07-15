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

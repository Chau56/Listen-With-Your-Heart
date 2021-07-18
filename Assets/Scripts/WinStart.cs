///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

public class WinStart : MonoBehaviour
{
    private void Awake()
    {
        RegisterEvnets();
    }

    private void RegisterEvnets()
    {
        var events = GameEvents.instance;
        events.GameWin += Deactivate;
        events.GameAwake += Activate;
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

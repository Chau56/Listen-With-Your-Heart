///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

public class WinCenter : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        var events = GameEvents.instance;
        events.GameWin += Activate;
        events.GameAwake += Deactivate;
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

///<summary>
///作者：周权
///创建日期：2021-7-12
///最新修改日期：2021-7-14
///</summary>


using UnityEngine;

public class CenterPointBehavior : MonoBehaviour
{
    private GameEvents events;
    private void Awake()
    {
        events = GameEvents.instance;
        gameObject.SetActive(false);
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GamePause += Activate;
        events.GameResume += Deactivate;
        events.GameEnd += Deactivate;
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

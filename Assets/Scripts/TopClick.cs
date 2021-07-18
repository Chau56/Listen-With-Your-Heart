///<summary>
///作者：周权
///创建日期：2021-7-17
///最新修改日期：2021-7-17
///</summary>


using UnityEngine;
using UnityEngine.EventSystems;

public class TopClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private GameEvents events = GameEvents.instance;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("top click down");
        events.StartJump2();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        events.FinishJump2();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("top click up");
        events.FinishJump2();
    }
}

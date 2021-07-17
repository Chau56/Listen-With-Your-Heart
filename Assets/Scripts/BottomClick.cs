using UnityEngine;
using UnityEngine.EventSystems;

public class BottomClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private GameEvents events = GameEvents.instance;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("bottom click down");
        events.StartJump1();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        events.FinishJump1();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("bottom click up");
        events.FinishJump1();
    }
}

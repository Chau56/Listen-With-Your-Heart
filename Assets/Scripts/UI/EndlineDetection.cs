///<summary>
///作者：张翔宇
///创建日期：2021-7-10
///更新者：周权
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EndlineDetection : MonoBehaviour
{
    private GameEvents events;
    // Start is called before the first frame update

    private void Start()
    {
        events = GameEvents.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.tag} hit end line");
        if (!collision.isTrigger) events.HitEndline();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log($"{collision.tag} stay end line");
        if (!collision.isTrigger) events.HitEndline();
    }
}

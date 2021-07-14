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
        events.HitEndline();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"{collision.tag} stay end line");
        events.HitEndline();
    }
}
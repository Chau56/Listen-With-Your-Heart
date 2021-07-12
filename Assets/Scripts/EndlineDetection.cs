using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EndlineDetection : MonoBehaviour
{
    [SerializeField]
    private GameEvents events;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.tag} hit end line");
        events.HitEndline();
    }
}
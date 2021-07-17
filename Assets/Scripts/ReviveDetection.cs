using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ReviveDetection : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("tag相同的都会被视为black玩家。")]
    private GameObject black;
    private string blackTag;
    [SerializeField]
    [Tooltip("tag相同的都会被视为white玩家。")]
    private GameObject white;
    private string whiteTag;

    private void Start()
    {
        events = GameEvents.instance;
        whiteTag = white.tag;
        blackTag = black.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectPlayer(collision.tag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectPlayer(collision.tag);
    }

    private void DetectPlayer(string tag)
    {
        if (tag == whiteTag)
        {
            Disappear();
            events.ReviveBlack();
        }
        else if (tag == blackTag)
        {
            Disappear();
            events.ReviveWhite();
        }
    }

    private void Disappear()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}

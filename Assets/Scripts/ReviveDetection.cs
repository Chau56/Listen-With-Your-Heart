using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ReviveDetection : MonoBehaviour
{
    [SerializeField]
    private GameEvents events;
    [SerializeField]
    [Tooltip("tag相同的都会被视为black玩家。")]
    private GameObject black;
    private string blackTag;
    [SerializeField]
    [Tooltip("tag相同的都会被视为white玩家。")]
    private GameObject white;
    private string whiteTag;
    private bool used;

    private void Start()
    {
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
        if (!used)
        {
            if (tag == whiteTag)
            {
                events.ReviveBlack();
                used = true;
            }
            else if (tag == blackTag)
            {
                events.ReviveWhite();
                used = true;
            }
        }
    }
}

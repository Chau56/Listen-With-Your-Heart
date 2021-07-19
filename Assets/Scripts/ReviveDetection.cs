///<summary>
///作者：周权
///创建日期：2021-7-12
///最新修改日期：2021-7-17
///</summary>


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
    private SpriteRenderer sprite;

    private void Start()
    {
        events = GameEvents.instance;
        sprite = GetComponent<SpriteRenderer>();
        whiteTag = white.tag;
        blackTag = black.tag;
        events.GameAwake += Appear;
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
        sprite.enabled = false;
    }

    private void Appear()
    {
        sprite.enabled = true;
    }
}

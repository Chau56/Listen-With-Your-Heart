using UnityEngine;

/// <summary>
/// 把这东西挂到cube上。
/// </summary>
[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer), typeof(Joint2D))]
public class DeathLogic : SwitchBehavior
{
    [SerializeField]
    [Tooltip("tag相同的都会被视为尖刺。")]
    private GameObject spikes;
    private string spikesTag;
    private new Collider2D collider;
    private SpriteRenderer sprite;
    private Joint2D joint;

    private void Start()
    {
        spikesTag = spikes.tag;
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        joint = GetComponent<Joint2D>();
        RegisterOtherEvents();
    }


    private void RegisterOtherEvents()
    {
        Swicher(() =>
        {
            events.BlackReviving += Revive;
            events.BlackDying += Die;
        }, () =>
        {
            events.WhiteReviving += Revive;
            events.WhiteDying += Die;
        });
        events.GameStart += Revive;
    }

    private void Revive()
    {
        sprite.enabled = true;
        collider.isTrigger = false;
        joint.enabled = false;
    }

    private void Die()
    {
        sprite.enabled = false;
        collider.isTrigger = true;
        joint.enabled = true;
    }

    //private void OnBecameInvisible()
    //{
    //    Debug.Log($"{tag} invisible.");
    //    Swicher(events.KillBlack, events.KillWhite);
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        DeathDetect(collision.gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathDetect(collision.gameObject.tag);
    }

    private void DeathDetect(string tag)
    {
        TagSensor(tag);
        SpeedSensor(collider.attachedRigidbody.velocity.x);
    }

    private void TagSensor(string tag)
    {
        Debug.Log($"{this.tag} enter or stay {tag}.");
        if (tag == spikesTag)
        {
            Swicher(events.KillBlack, events.KillWhite);
        }
    }

    private void SpeedSensor(float x)
    {
        Debug.Log($"{tag} velocity {x}.");
        if (x < 1)
        {
            Swicher(events.KillBlack, events.KillWhite);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{this.tag} exit {tag}.");
    }

}

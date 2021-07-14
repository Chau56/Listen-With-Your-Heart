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
        RegisterEvents();
    }


    private void RegisterEvents()
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
        events.GameAwake += Die;
        events.GameStart += Revive;
        events.GameEnd += Die;
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

    private void KillBlack()
    {
        events.KillBlack();
    }
    private void KillWhite()
    {
        events.KillWhite();
    }

    private void Kill()
    {
        Swicher(KillBlack, KillWhite);
    }

    //private void OnBecameInvisible()
    //{
    //    Debug.Log($"{tag} invisible.");
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        DeathDetect(collision.gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string ctag = collision.gameObject.tag;
        Debug.Log($"{tag} enter {ctag}, velocity {collider.attachedRigidbody.velocity}");
        DeathDetect(ctag);
    }

    private void DeathDetect(string tag)
    {
        TagSensor(tag);
        SpeedSensor(collider.attachedRigidbody.velocity.x);
    }

    private void TagSensor(string tag)
    {
        if (tag == spikesTag)
        {
            Kill();
        }
    }

    private void SpeedSensor(float x)
    {
        if (x < 1)
        {
            Kill();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{this.tag} exit {tag}.");
    }

}

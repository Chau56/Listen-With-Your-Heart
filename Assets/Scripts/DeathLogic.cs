using System;
using UnityEngine;

/// <summary>
/// 把这东西挂到cube上。
/// </summary>
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class DeathLogic : MonoBehaviour
{
    /// <summary>
    /// 检测到死亡就会触发。
    /// </summary>
    public event Action OnDied;
    /// <summary>
    /// 碰到复活点就会触发。
    /// </summary>
    public event Action OnRevive;
    [SerializeField]
    [Tooltip("tag相同的都会被视为尖刺。")]
    private GameObject spikes;
    private string spikesTag;
    [SerializeField]
    [Tooltip("tag相同的都会被视为复活点。")]
    private GameObject revivePoint;
    private string reviveTag;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private GameEvents events;
    private bool paused, died;
    // Start is called before the first frame update
    private void Start()
    {
        paused = true;
        spikesTag = spikes.tag;
        //wallsTag = walls.tag;
        reviveTag = revivePoint.tag;
        rigidbody = GetComponent<Rigidbody2D>();
        RegisterSelfEvents();
        RegisterEvents();
    }

    private void DiedCheck()
    {
        if (!paused) OnDied();
    }

    private void ReviveCheck()
    {
        if (!paused && died) OnRevive();
    }

    private void RegisterSelfEvents()
    {
        OnDied += () =>
        {
            gameObject.SetActive(false);
            died = true;
            Debug.Log($"{tag} died.");
        };
        OnRevive += () =>
        {
            gameObject.SetActive(true);
            died = false;
            Debug.Log($"{tag} revived.");
        };
    }

    private void RegisterEvents()
    {
        events.GameStart += Resume;
        events.GamePause += Pause;
        events.GameResume += Resume;
    }

    private void Pause()
    {
        Debug.Log("deathlogic pause");
        paused = true;
    }

    private void Resume()
    {
        Debug.Log("deathlogic resume");
        paused = false;
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        if (gameObject.activeInHierarchy) DiedCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagSensor(collision.gameObject.tag);
        SpeedSensor(rigidbody.velocity.x);
    }

    private void TagSensor(string tag)
    {
        Debug.Log($"{this.tag} enter {tag}.");
        if (tag == spikesTag)
        {
            DiedCheck();
        }
        else if (tag == reviveTag)
        {
            ReviveCheck();
        }
    }

    private void SpeedSensor(float x)
    {
        Debug.Log($"{tag} velocity {x}.");
        if (x < 1)
        {
            DiedCheck();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{this.tag} stay in {tag}.");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{this.tag} exit {tag}.");
    }
}

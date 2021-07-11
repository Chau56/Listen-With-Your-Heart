using System;
using UnityEngine;

/// <summary>
/// ���ⶫ���ҵ�cube�ϡ�
/// </summary>
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class DeathLogic : MonoBehaviour
{
    /// <summary>
    /// ��⵽�����ͻᴥ����
    /// </summary>
    public event Action OnDied;
    /// <summary>
    /// ����������������ͻᴥ���������Ǹ����ʱ������
    /// </summary>
    public event Action OnHitRevive;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ��̡�")]
    private GameObject spikes;
    private string spikesTag;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ����㡣")]
    private GameObject revivePoint;
    private string reviveTag;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private GameEvents events;
    [SerializeField]
    [Tooltip("�����ĸ���ң�")]
    private PlayerEnum player;
    private bool notEnd, died;
    // Start is called before the first frame update
    private void Start()
    {
        spikesTag = spikes.tag;
        reviveTag = revivePoint.tag;
        rigidbody = GetComponent<Rigidbody2D>();
        RegisterSelfEvents();
        RegisterOtherEvents();
    }

    private void RegisterSelfEvents()
    {
        OnDied += () => Debug.Log($"{tag} died.");
        OnHitRevive += () => Debug.Log($"{tag} hit revivepoint.");
    }

    private void RegisterOtherEvents()
    {
        events.GameStart += GameStart;
        events.GameFailed += GameEnd;
        events.GameWin += GameEnd;
        switch (player)
        {
            case PlayerEnum.Black:
                events.BlackWillRevive += Revive;
                break;
            case PlayerEnum.White:
                events.WhiteWillRevive += Revive;
                break;
        }
    }

    private void GameStart()
    {
        notEnd = true;
    }

    private void GameEnd()
    {
        notEnd = false;
    }

    private void Die()
    {
        if (CheckValid())
        {
            died = true;
            gameObject.SetActive(false);
            OnDied();
        }
    }

    private void HitRevive()
    {
        if (CheckValid())
        {
            OnHitRevive();
        }
    }

    private void Revive()
    {
        Debug.Log("opposite hit revive");
        if (died)
        {
            died = false;
            gameObject.SetActive(true);
        }
    }

    private bool CheckValid()
    {
        return !died && notEnd;
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        Die();
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
            Die();
        }
        else if (tag == reviveTag)
        {
            HitRevive();
        }
    }

    private void SpeedSensor(float x)
    {
        Debug.Log($"{tag} velocity {x}.");
        if (x < 1)
        {
            Die();
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

    private void OnApplicationQuit()
    {
        notEnd = false;
    }
}

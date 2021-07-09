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
    /// ���������ͻᴥ����
    /// </summary>
    public event Action OnRevive;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ��̡�")]
    private GameObject spikes;
    private string spikesTag;
    //[SerializeField]
    //[Tooltip("tag��ͬ�Ķ��ᱻ��Ϊǽ��")]
    //private GameObject walls;
    //private string wallsTag;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ����㡣")]
    private GameObject revivePoint;
    private string reviveTag;
    private new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    private void Start()
    {
        spikesTag = spikes.tag;
        //wallsTag = walls.tag;
        reviveTag = revivePoint.tag;
        rigidbody = GetComponent<Rigidbody2D>();
        RegisterSelfEvents();
    }
    private void RegisterSelfEvents()
    {
        OnDied += () =>
        {
            gameObject.SetActive(false);
            Debug.Log($"{tag} died.");
        };
        OnRevive += () =>
        {
            gameObject.SetActive(true);
            Debug.Log($"{tag} revived.");
        };
    }

    private void RevokeSelfEvents()
    {
        OnDied = () => { };
        OnRevive = () => { };
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        if (gameObject.activeInHierarchy) OnDied();
    }

    //private bool IsDeathCollision(ContactPoint2D point)
    //{
    //    float positionY = transform.InverseTransformPoint(point.point).y;
    //    Debug.Log($"{tag} death collision y {positionY}");
    //    return positionY >= -0.49f && positionY <= 0.49f;
    //}

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
            OnDied();
        }
        else if (tag == reviveTag)
        {
            OnRevive();
        }
    }

    private void SpeedSensor(float x)
    {
        Debug.Log($"{tag} velocity {x}.");
        if (x < 1)
        {
            OnDied();
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

    private void OnDestroy()
    {
        RevokeSelfEvents();
    }
}

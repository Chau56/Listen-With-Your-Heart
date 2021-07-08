using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ���ⶫ���ҵ�cube�ϡ�
/// </summary>
[RequireComponent(typeof(Collider2D))]
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
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊǽ��")]
    private GameObject walls;
    private string wallsTag;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ����㡣")]
    private GameObject revivePoint;
    private string reviveTag;
    // Start is called before the first frame update
    private void Start()
    {
        spikesTag = spikes.tag;
        wallsTag = walls.tag;
        reviveTag = revivePoint.tag;
        OnDied += () => Debug.Log($"{tag} died.");
        OnDied += () => gameObject.SetActive(false);
        OnRevive += () => Debug.Log($"{tag} revived.");
        OnRevive += () => gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        if (gameObject.activeInHierarchy) OnDied();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{this.tag} enter {tag}.");
        if (tag == spikesTag)
        {
            OnDied();
        }
        else if (tag == wallsTag && collision.contacts.All(point =>
            {
                Debug.Log($"{this.tag} death collision {point.normal}");
                return point.normal.x > 0.2f;
            }
        ))
        {
            OnDied();
        }
        else if (tag == reviveTag)
        {
            OnRevive();
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

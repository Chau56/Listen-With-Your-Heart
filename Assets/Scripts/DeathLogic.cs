using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊ��̡�")]
    private GameObject spikes;
    private string spikesTag;
    [SerializeField]
    [Tooltip("tag��ͬ�Ķ��ᱻ��Ϊǽ��")]
    private GameObject walls;
    private string wallsTag;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Assert(spikes, spikes);
        Debug.Assert(walls, walls);
        spikesTag = spikes.tag;
        wallsTag = walls.tag;
        OnDied += () => Debug.Log($"{tag} died.");
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        OnDied();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{tag} entered.");
        if (tag == spikesTag)
        {
            OnDied();
        }
        if (tag == wallsTag)
        {
            OnDied();
        }
    }
}

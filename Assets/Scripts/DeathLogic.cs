using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 把这东西挂到cube上。
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class DeathLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("检测到死亡就会触发。")]
    private UnityEvent OnDied;
    [SerializeField]
    [Tooltip("tag相同的都会被视为尖刺。")]
    private Collider2D spikes;
    private string spikesTag;
    [SerializeField]
    [Tooltip("tag相同的都会被视为墙。")]
    private Collider2D walls;
    private string wallsTag;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Assert(spikes);
        Debug.Assert(walls);
        spikesTag = spikes.tag;
        wallsTag = walls.tag;
        OnDied.AddListener(() => Debug.Log($"{tag} died."));
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{tag} invisible.");
        OnDied.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        Debug.Log($"{tag} entered.");
        if (tag == spikesTag)
        {
            OnDied.Invoke();
        }
        if (tag == wallsTag)
        {
            OnDied.Invoke();
        }
    }
}

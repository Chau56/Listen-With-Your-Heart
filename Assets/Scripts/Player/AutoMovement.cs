///<summary>
///作者：周澄鑫
///创建日期：2021-7-6
///更新者：周权、施欣怡
///最新修改日期：2021-7-17
///</summary>

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : SwitchBehavior
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("物体移动速度")]
    private Vector2 speed = new Vector2(8.5f, 0);
    private Vector3 startPosition;
    private Vector2 velocityPaused;
    [SerializeField]
    private bool shouldImpulse;
    /// <summary>
    /// 施加脉冲力。
    /// </summary>
    private IEnumerator Impulse()
    {
        if (!shouldImpulse) yield break;
        yield return new WaitForFixedUpdate();
        myRigidbody.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} impulse velocity {myRigidbody.velocity}");
    }
    private void Resume()
    {
        myRigidbody.velocity = velocityPaused;
        if (shouldImpulse) StartCoroutine(Impulse());
    }
    /// <summary>
    /// 速度归零。
    /// </summary>
    private void Pause()
    {
        velocityPaused = myRigidbody.velocity;
        myRigidbody.velocity = Vector2.zero;
    }
    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    private void Start()
    {
        startPosition = transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameStart += () => StartCoroutine(Impulse());
        events.GamePause += Pause;
        events.GameResume += Resume;
        events.GameAbnormalEnd += Pause;
        events.GameAwake += ResetPosition;
    }
}

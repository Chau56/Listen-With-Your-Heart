using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    private GameEvents events;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    [Tooltip("物体移动力")]
    private Vector2 velocity = new Vector2(8.5f, 0);
    private Vector2 velocityPaused;
    /// <summary>
    /// 施加脉冲力。
    /// </summary>
    private IEnumerator Impulse()
    {
        yield return new WaitForEndOfFrame();
        rigidbody.velocity = velocity;
        Debug.Log($"{tag} impulse velocity {rigidbody.velocity}");
    }
    private void Resume()
    {
        rigidbody.velocity = velocityPaused;
    }
    /// <summary>
    /// 速度归零。
    /// </summary>
    private void Pause()
    {
        velocityPaused = rigidbody.velocity;
        rigidbody.velocity = Vector2.zero;
    }
    private void Start()
    {
        events = GameEvents.instance;
        rigidbody = GetComponent<Rigidbody2D>();
        events.GameFailed += Pause;
        events.GameStart += () => StartCoroutine(Impulse());
        events.GamePause += Pause;
        events.GameResume += Resume;
        events.GameWin += Pause;
    }

}

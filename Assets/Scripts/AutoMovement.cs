using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("物体移动速度")]
    private Vector2 speed = new Vector2(8.5f, 0);
    [SerializeField]
    private GameEvents events;
    /// <summary>
    /// 施加脉冲力。
    /// </summary>
    private void Impulse()
    {
        myRigidbody.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} velocity {myRigidbody.velocity}");
    }
    /// <summary>
    /// 速度归零。
    /// </summary>
    private void Pause()
    {
        myRigidbody.velocity = Vector2.zero;
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameStart += Impulse;
        events.GamePause += Pause;
        events.GameResume += Impulse;
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMovement : SwitchBehavior
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    [Tooltip("�����ƶ��ٶ�")]
    private Vector2 speed = new Vector2(8.5f, 0);
    private Vector2 velocityPaused;
    /// <summary>
    /// ʩ����������
    /// </summary>
    private IEnumerator Impulse()
    {
        yield return new WaitForEndOfFrame();
        myRigidbody.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log($"{tag} impulse velocity {myRigidbody.velocity}");
    }
    private void Resume()
    {
        myRigidbody.velocity = velocityPaused;
    }
    /// <summary>
    /// �ٶȹ��㡣
    /// </summary>
    private void Pause()
    {
        velocityPaused = myRigidbody.velocity;
        myRigidbody.velocity = Vector2.zero;
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        events.GameStart += () => StartCoroutine(Impulse());
        events.GamePause += Pause;
        events.GameResume += Resume;
    }
}

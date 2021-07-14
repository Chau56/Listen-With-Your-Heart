using UnityEngine;
using UnityEditor;
using System.Collections;

public class AutoJump : MonoBehaviour
{
    private GameEvents events;
    //private bool canJump;
    //private Rigidbody2D rigid;
    //[SerializeField]
    //private Vector2 jumpSpeed = new Vector2(0, 17);
    //[SerializeField]
    //private Vector2 speed = new Vector2(8.5f, 0);
    //[SerializeField]
    //private Vector3 redrawPosion = new Vector3(-18, 5.5f, 0);
    //[SerializeField]
    //private GameObject RedrawPrefab;
    [SerializeField]
    [Tooltip("随机跳跃概率")]
    private float randomProbability = 0.001f;//随即跳跃概率
    [SerializeField]
    [Tooltip("跳跃持续时间")]
    private float jumpTime = 0.001f;//随即跳跃概率

    private IEnumerator Start()
    {
        events = GameEvents.instance;
        //rigid = GetComponent<Rigidbody2D>();
        //canJump = true;
        //AddHorizonSpeed();
        yield return new WaitForEndOfFrame();
        events.StartGame();
    }

    private void Update()
    {
        if (Random.value < randomProbability)
        {
            events.StartJump1();
            StartCoroutine(FinishJump(true));
        }
        if (Random.value < randomProbability)
        {
            events.StartJump2();
            StartCoroutine(FinishJump(false));
        }

    }

    private IEnumerator FinishJump(bool black)
    {
        yield return new WaitForSecondsRealtime(jumpTime);
        if (black)
        {
            events.FinishJump1();
        }
        else
        {
            events.FinishJump2();
        }
    }
    //private void AddHorizonSpeed()
    //{
    //    rigid.AddForce(speed, ForceMode2D.Impulse);
    //}

    //private void Jump()
    //{
    //    rigid.AddForce(jumpSpeed, ForceMode2D.Impulse);
    //    canJump = false;
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"{tag} enter {collision.gameObject.tag}");
    //    if (collision.collider.CompareTag("Road"))
    //        canJump = true;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log($"{tag} enter {collision.gameObject.tag}");

    //    if (collision.CompareTag("cubeRedraw"))
    //    {
    //        Destroy(gameObject);
    //        var obj = Instantiate(RedrawPrefab, redrawPosion, new Quaternion());
    //        obj.GetComponent<Collider2D>().enabled = true;
    //        obj.GetComponent<AutoJump>().enabled = true;
    //        obj.GetComponent<AutoMovement>().enabled = true;
    //        events.StartGame();
    //    }
    //}

}

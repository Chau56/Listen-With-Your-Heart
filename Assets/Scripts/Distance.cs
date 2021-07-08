using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    private Text distance;
    [SerializeField]
    [Tooltip("立即激活进度条。")]
    private bool immediate;
    [SerializeField]
    [Tooltip("关联的cube")]
    private DeathLogic playerSelf;
    [SerializeField]
    [Tooltip("另一个cube")]
    private DeathLogic playerAnother;
    [SerializeField]
    [Tooltip("增长速度。每秒增长50次speed。")]
    private int speed = 1;
    /// <summary>
    /// 向外暴露的距离值。
    /// </summary>
    public int DistanceValue
    {
        get
        {
            Debug.Log($"{playerSelf.tag} {nameof(DistanceValue)} get.");
            return value;
        }
    }
    /// <summary>
    /// 真正的值。
    /// </summary>
    private int value;
    /// <summary>
    /// 激活进度条。
    /// </summary>
    public void StartProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StartProgress)}");
        enabled = true;
    }
    /// <summary>
    /// 停止进度条。
    /// </summary>
    public void StopProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StopProgress)}");
        if (this) enabled = false;
    }
    /// <summary>
    /// 重置进度条。
    /// </summary>
    public void ResetProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(ResetProgress)}");
        value = 0;
        distance.text = "0";
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerSelf.OnDied += StopProgress;
        playerAnother.OnRevive += StartProgress;
        distance = GetComponent<Text>();
        enabled = immediate;
        var input = InGameActionDistribute.instance;
        input.GamePause += StopProgress;
        input.GameResume += StartProgress;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        value += speed;
        distance.text = value.ToString();
    }
}

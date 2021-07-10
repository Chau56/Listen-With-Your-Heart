using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    private Text distance;
    [SerializeField]
    [Tooltip("关联的cube")]
    private DeathLogic playerSelf;
    [SerializeField]
    [Tooltip("另一个cube")]
    private DeathLogic playerAnother;
    [SerializeField]
    [Tooltip("增长速度。每秒增长50次speed。")]
    private int speed = 1;
    [SerializeField]
    private GameEvents events;
    private bool run;
    private bool died;
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
        run = true;
    }
    /// <summary>
    /// 停止进度条。
    /// </summary>
    public void StopProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StopProgress)}");
        run = false;
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
        run = false;
        distance = GetComponent<Text>();
        RegisterSelfEvents();
        RegisterInputEvents();
    }

    private void RegisterSelfEvents()
    {
        playerSelf.OnDied += () =>
        {
            StopProgress();
            died = true;
        };
        playerAnother.OnHitRevive += () =>
        {
            StartProgress();
            died = false;
        };
    }

    private void RegisterInputEvents()
    {
        events.GamePause += StopProgress;
        events.GameResume += () =>
        {
            if (!died) StartProgress();
        };
        events.GameStart += StartProgress;
        events.GameWin += StopProgress;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (run)
        {
            value += speed;
            distance.text = value.ToString();
        }
    }
}

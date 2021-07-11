using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    private Text distance;
    [SerializeField]
    [Tooltip("这是哪个玩家的距离指示器？")]
    private PlayerEnum player;
    [SerializeField]
    [Tooltip("增长速度。每秒增长50次speed。")]
    private int speed = 1;
    [SerializeField]
    private GameEvents events;
    private bool run, died;
    /// <summary>
    /// 向外暴露的距离值。
    /// </summary>
    public int DistanceValue
    {
        get
        {
            Debug.Log($"{player} {nameof(DistanceValue)} get.");
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
    private void StartProgress()
    {
        if (!died)
        {
            Debug.Log($"{player} {nameof(StartProgress)}");
            run = true;
        }
    }
    /// <summary>
    /// 停止进度条。
    /// </summary>
    private void StopProgress()
    {
        Debug.Log($"{player} {nameof(StopProgress)}");
        run = false;
    }
    private void Die()
    {
        died = true;
        StopProgress();
    }
    private void Revive()
    {
        died = false;
        StartProgress();
    }
    /// <summary>
    /// 重置进度条。
    /// </summary>
    //private void ResetProgress()
    //{
    //    Debug.Log($"{player} {nameof(ResetProgress)}");
    //    value = 0;
    //    distance.text = "0";
    //}

    // Start is called before the first frame update
    private void Start()
    {
        distance = GetComponent<Text>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        switch (player)
        {
            case PlayerEnum.Black:
                events.BlackDied += Die;
                events.BlackWillRevive += Revive;
                break;
            case PlayerEnum.White:
                events.WhiteDied += Die;
                events.WhiteWillRevive += Revive;
                break;
        }
        events.GamePause += StopProgress;
        events.GameResume += StartProgress;
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

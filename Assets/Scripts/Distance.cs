///<summary>
///作者：周权
///创建日期：2021-7-6
///最新修改日期：2021-7-19
///</summary>


using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : SwitchBehavior
{
    private Text distance;
    [SerializeField]
    [Tooltip("增长速度。每秒增长50次speed。")]
    private int speed = 1;
    private bool run, bonus;

    public int Bonus
    {
        get; private set;
    }

    public void StartBonus()
    {
        bonus = true;
    }

    public void EndBonus()
    {
        bonus = false;
    }
    /// <summary>
    /// 不含Bonus的距离。
    /// </summary>
    public int Value
    {
        get;
        private set;
    }
    /// <summary>
    /// 激活进度条。
    /// </summary>
    private void StartProgress()
    {
        run = true;
    }
    /// <summary>
    /// 停止进度条。
    /// </summary>
    private void StopProgress()
    {
        run = false;
    }
    /// <summary>
    /// 重置进度条。
    /// </summary>
    private void ResetProgress()
    {
        Debug.Log($"{player} {nameof(ResetProgress)}");
        Value = 0;
        Bonus = 0;
        distance.text = "0";
    }

    // Start is called before the first frame update
    private void Start()
    {
        distance = GetComponent<Text>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        Swicher(() =>
        {
            events.BlackProcessStart += StartProgress;
            events.BlackProcessEnd += StopProgress;
        }, () =>
        {
            events.WhiteProcessStart += StartProgress;
            events.WhiteProcessEnd += StopProgress;
        });
        events.GameBeforeAwake += ResetProgress;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (run)
        {
            Value += speed;
            distance.text = Value.ToString();
            if (bonus)
            {
                Bonus += speed;
            }
        }
    }
}

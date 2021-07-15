using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : SwitchBehavior
{
    private Text distance;
    [SerializeField]
    [Tooltip("�����ٶȡ�ÿ������50��speed��")]
    private int speed = 1;
    private bool run;
    private int bonusStart;

    public int Bonus
    {
        get; private set;
    }

    public void StartBonus()
    {
        bonusStart = Value;
    }

    public void EndBonus()
    {
        Bonus += Value - bonusStart;
    }
    /// <summary>
    /// ����Bonus�ľ��롣
    /// </summary>
    public int Value
    {
        get;
        private set;
    }
    /// <summary>
    /// �����������
    /// </summary>
    private void StartProgress()
    {
        run = true;
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    private void StopProgress()
    {
        run = false;
    }
    /// <summary>
    /// ���ý�������
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
        events.GameAwake += ResetProgress;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (run)
        {
            Value += speed;
            distance.text = Value.ToString();
        }
    }
}

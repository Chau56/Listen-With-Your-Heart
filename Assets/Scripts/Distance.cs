using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : SwitchBehavior
{
    private Text distance;
    [SerializeField]
    [Tooltip("�����ٶȡ�ÿ������50��speed��")]
    private int speed = 1;
    private bool run, died;
    /// <summary>
    /// ���Ⱪ¶�ľ���ֵ��
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
    /// ������ֵ��
    /// </summary>
    private int value;
    /// <summary>
    /// �����������
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
    /// ֹͣ��������
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
    /// ���ý�������
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
        Swicher(() =>
        {
            events.BlackDying += Die;
            events.BlackReviving += Revive;
        }, () =>
        {
            events.WhiteDying += Die;
            events.WhiteReviving += Revive;
        });
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

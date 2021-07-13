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
    /// <summary>
    /// ������ֵ��
    /// </summary>
    private int value;
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
            events.BlackProcessStart += StartProgress;
            events.BlackProcessEnd += StopProgress;
        }, () =>
        {
            events.WhiteProcessStart += StartProgress;
            events.WhiteProcessEnd += StopProgress;
        });
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

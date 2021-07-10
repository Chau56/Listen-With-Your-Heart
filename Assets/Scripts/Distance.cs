using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    private Text distance;
    [SerializeField]
    [Tooltip("������cube")]
    private DeathLogic playerSelf;
    [SerializeField]
    [Tooltip("��һ��cube")]
    private DeathLogic playerAnother;
    [SerializeField]
    [Tooltip("�����ٶȡ�ÿ������50��speed��")]
    private int speed = 1;
    [SerializeField]
    private GameEvents events;
    private bool run;
    private bool died;
    /// <summary>
    /// ���Ⱪ¶�ľ���ֵ��
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
    /// ������ֵ��
    /// </summary>
    private int value;
    /// <summary>
    /// �����������
    /// </summary>
    public void StartProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StartProgress)}");
        run = true;
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StopProgress)}");
        run = false;
    }
    /// <summary>
    /// ���ý�������
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

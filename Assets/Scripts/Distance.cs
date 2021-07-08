using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    private Text distance;
    [SerializeField]
    [Tooltip("���������������")]
    private bool immediate;
    [SerializeField]
    [Tooltip("������cube")]
    private DeathLogic playerSelf;
    [SerializeField]
    [Tooltip("��һ��cube")]
    private DeathLogic playerAnother;
    [SerializeField]
    [Tooltip("�����ٶȡ�ÿ������50��speed��")]
    private int speed = 1;
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
        enabled = true;
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopProgress()
    {
        Debug.Log($"{playerSelf.tag} {nameof(StopProgress)}");
        if (this) enabled = false;
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

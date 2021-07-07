using System.Collections;
using System.Collections.Generic;
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
    [Tooltip("�����ٶȡ�ÿ������50��speed��")]
    private int speed = 1;
    /// <summary>
    /// ���Ⱪ¶�ľ���ֵ��
    /// </summary>
    public int DistanceValue
    {
        get
        {
            Debug.Log($"{nameof(DistanceValue)} get.");
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
        Debug.Log($"{nameof(StartProgress)}");
        enabled = true;
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopProgress()
    {
        Debug.Log($"{nameof(StopProgress)}");
        enabled = false;
    }
    /// <summary>
    /// ���ý�������
    /// </summary>
    public void ResetProgress()
    {
        Debug.Log($"{nameof(ResetProgress)}");
        value = 0;
        distance.text = "0";
    }

    // Start is called before the first frame update
    private void Start()
    {
        distance = GetComponent<Text>();
        enabled = immediate;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        value += speed;
        distance.text = value.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    Text distance;
    [SerializeField]
    [Tooltip("���������������")]
    bool immediate;
    [SerializeField]
    [Tooltip("�����ٶȡ�ÿ������50�Ρ�")]
    int speed = 1;
    /// <summary>
    /// ������ֵ��
    /// </summary>
    int value;
    /// <summary>
    /// �������������������ʱ�Զ�ֹͣ��
    /// </summary>
    public void StartProgress()
    {
        enabled = true;
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopProgress()
    {
        enabled = false;
    }
    /// <summary>
    /// ���ý�������
    /// </summary>
    public void ResetProgress()
    {
        distance.text = "0";
    }
    // Start is called before the first frame update
    void Start()
    {
        distance = GetComponent<Text>();
        enabled = immediate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        value += speed;
        distance.text = value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    Text distance;
    //[SerializeField]
    //[Tooltip("�ᱻsource���ǡ������ڲ��ԡ�")]
    //float maxValue;
    //[SerializeField]
    //[Tooltip("�ô�source��clip�����maxValue��")]
    //AudioSource source;
    [SerializeField]
    [Tooltip("���������������")]
    bool immediate;
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
        value += 1;
        distance.text = value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    Text distance;
    //[SerializeField]
    //[Tooltip("会被source覆盖。仅用于测试。")]
    //float maxValue;
    //[SerializeField]
    //[Tooltip("用此source的clip计算出maxValue。")]
    //AudioSource source;
    [SerializeField]
    [Tooltip("立即激活进度条。")]
    bool immediate;
    /// <summary>
    /// 真正的值。
    /// </summary>
    int value;
    /// <summary>
    /// 激活进度条。歌曲结束时自动停止。
    /// </summary>
    public void StartProgress()
    {
        enabled = true;
    }
    /// <summary>
    /// 停止进度条。
    /// </summary>
    public void StopProgress()
    {
        enabled = false;
    }
    /// <summary>
    /// 重置进度条。
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

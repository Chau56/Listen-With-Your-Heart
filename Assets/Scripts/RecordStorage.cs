using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class RecordStorage : SwitchBehavior
{
    [SerializeField]
    private Slider[] sliders;
    [SerializeField]
    private Distance D1;
    [SerializeField]
    private Distance D2;
    [Tooltip("分数值")]
    private int scoreValue;
    [Tooltip("通关时的关卡完成度")]
    private int endRateValue;
    [Tooltip("失败时关卡进度")]
    private int failRateValue;
    [Tooltip("存取两类slider各类所拥有Value属性的最大值")]
    private float[] trueRate = new float[2];

    public void getEndScore()
    { //获取通关分数
        scoreValue = D1.Bonus + D1.Value + D2.Value + D2.Bonus;
    }
    public void getEndRate()
    {
        endRateValue = Mathf.RoundToInt(trueRate[1]);

    }
    public void getFailRate()
    {
        if (!GameEvents.instance.EndGame())
        {
            failRateValue = Mathf.RoundToInt(trueRate[0]);

        }
    }
    public void store(int score, int endrate, int failrate)
    {
        if (!CheckFailRate(failrate))
        {
            PlayerPrefs.SetInt("FailedRate", failrate);//失败
        }
        if (!CheckScore(score) || !CheckFinishRate(endrate))
        {
            PlayerPrefs.SetInt("Score", score); //通关
            PlayerPrefs.SetInt("FinishRate", endrate);
        }
    }
    private bool CheckScore(int score)
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            return false;
        }
        if (score > PlayerPrefs.GetInt("Score"))
        {
            return false;
        }
        return true;
    }
    private bool CheckFinishRate(int rate)
    {
        if (!PlayerPrefs.HasKey("FinishRate"))
        {
            return false;
        }
        if (rate > PlayerPrefs.GetInt("FinishRate"))
        {
            return false;
        }
        return true;
    }
    private bool CheckFailRate(int rate)
    {
        if (!PlayerPrefs.HasKey("FailedRate"))
        {
            return false;
        }
        if (rate > PlayerPrefs.GetInt("FailedRate"))
        {
            return false;
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        GameEvents.instance.GameWin += getEndRate;
        GameEvents.instance.GameFailed += getFailRate;
        GameEvents.instance.GameStart += debugTest;
    }
    void debugTest()
    {
        Debug.Log("Score: " + PlayerPrefs.GetInt("Score"));
        Debug.Log("Finished: " + PlayerPrefs.GetInt("FinishedRate"));
        Debug.Log("Failed: " + PlayerPrefs.GetInt("FailedRate"));
    }
    // Update is called once per frame
    void Update()
    {
        trueRate[0] = sliders[0].value > sliders[1].value ? sliders[0].value : sliders[1].value;
        trueRate[1] = sliders[2].value > sliders[3].value ? sliders[2].value : sliders[3].value;
        getEndScore();
        getEndRate();
        store(scoreValue, endRateValue, failRateValue);

    }
}
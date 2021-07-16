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
    [Tooltip("�洢����ֵ")]
    private int scoreValue;
    [Tooltip("�洢����")]
    private int endRateValue;
    private int failRateValue;
    [Tooltip("��ȡ���������ÿ�������������value")]
    private float[] trueRate = new float[2];
    [SerializeField]
    private Transform revivePoint;
    [SerializeField]
    private Transform endline;
    private float trueStartPosition, startPosition;
    private float currentLen;
    private float totalLen;
    public int Percent
    {
        get
        {
            return Mathf.RoundToInt(currentLen / totalLen * 100);
        }
    }
    public void getEndScore()
    { //ͨ�صķ���,���������ӿ�
        scoreValue = D1.Bonus + D1.Value + D2.Value + D2.Bonus;
    }
    public void getEndRate()
    {
        endRateValue = Mathf.RoundToInt(trueRate[1] * 100);

    }
    public void getFailRate()
    {
        if (!GameEvents.instance.EndGame())
        {
            failRateValue = Percent;

        }
    }
    public void store(int score, int endrate, int failrate)
    {
        if (!CheckFailRate(failrate))
        {
            PlayerPrefs.SetInt("FailedRate", failrate);//�洢ʧ��ʱ�Ĺؿ�����
        }
        if (!CheckScore(score) || !CheckFinishRate(endrate))
        {
            PlayerPrefs.SetInt("Score", score); //�洢ͨ��ʱ��������ɶ�
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
    private void Add()
    {
        currentLen += revivePoint.position.x - startPosition;
        startPosition = revivePoint.position.x;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        trueRate[0] = sliders[0].value > sliders[1].value ? sliders[0].value : sliders[1].value;
        trueRate[1] = sliders[2].value > sliders[3].value ? sliders[2].value : sliders[3].value;
        trueStartPosition = revivePoint.position.x;
        startPosition = trueStartPosition;
        totalLen = endline.position.x - startPosition;
        Swicher(() =>
        {
            events.BlackProcessEnd += Add;
        }, () =>
        {
            events.WhiteProcessEnd += Add;
        });

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
        getEndScore();
        getEndRate();
        store(scoreValue, endRateValue, failRateValue);

    }
}

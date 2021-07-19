///<summary>
///作者：周权
///创建日期：2021-7-13
///最新修改日期：2021-7-16
///</summary>


using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressCalculate : SwitchBehavior
{
    [SerializeField]
    private Transform revivePoint;
    [SerializeField]
    private Transform endline;
    [SerializeField]
    private Text percent;
    private float trueStartPosition, startPosition;
    private float currentLen;
    private float totalLen;
    private Slider slider;

    public int Percent
    {
        get
        {
            return Mathf.RoundToInt(currentLen / totalLen * 100);
        }
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        trueStartPosition = revivePoint.position.x;
        startPosition = trueStartPosition;
        totalLen = endline.position.x - startPosition;
        Swicher(() =>
        {
            events.BlackDying += Show;
            events.BlackReviving += SetStartPosition;
        }, () =>
         {
             events.WhiteDying += Show;
             events.WhiteReviving += SetStartPosition;
         });
        events.GamePause += Show;
        events.GameEnd += Show;
        events.GameBeforeAwake += ResetProgress;
    }

    private void SetStartPosition()
    {
        startPosition = revivePoint.position.x;
    }

    private void Show()
    {
        currentLen += revivePoint.position.x - startPosition;
        SetStartPosition();
        slider.value = Percent;
        percent.text = $"{Percent}%";
    }

    private void ResetProgress()
    {
        currentLen = 0;
        startPosition = trueStartPosition;
    }
}

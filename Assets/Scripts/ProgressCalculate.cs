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
        events.GameWin += Show;
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

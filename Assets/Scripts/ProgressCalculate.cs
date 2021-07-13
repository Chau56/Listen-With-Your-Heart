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
    private float startPosition;
    private float currentLen;
    private float totalLen;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        startPosition = revivePoint.position.x;
        totalLen = endline.position.x - startPosition;
        Swicher(() =>
        {
            events.BlackProcessEnd += Add;
        }, () =>
         {
             events.WhiteProcessEnd += Add;
         });
        events.GamePause += Show;
    }

    private void Add()
    {
        currentLen += revivePoint.position.x - startPosition;
        startPosition = revivePoint.position.x;
    }

    private void Show()
    {
        int value = (int)(currentLen / totalLen * 100);
        slider.value = value;
        percent.text = $"{value}%";
    }
}
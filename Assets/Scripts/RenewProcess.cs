///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-16
///</summary>


using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RenewProcess : MonoBehaviour
{
    [SerializeField]
    private ProgressCalculate progress;
    [SerializeField]
    private Text percent;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        var events = GameEvents.instance;
        events.GameEnd += Renew;
    }
    private void Renew()
    {
        int value = progress.Percent;
        percent.text = $"{value}%";
        slider.value = value;
    }
}

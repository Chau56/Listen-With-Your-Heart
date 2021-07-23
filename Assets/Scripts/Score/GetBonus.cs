///<summary>
///作者：周权
///创建日期：2021-7-15
///最新修改日期：2021-7-15
///</summary>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetBonus : MonoBehaviour
{
    private Text text;
    [SerializeField]
    private Distance distance;
    private int maxValue;
    private int minValue;
    private int Times;
    private GameEvents events;
    private void Start()
    {
        text = GetComponent<Text>();
        events = GameEvents.instance;
        events.GameWin += () => text.text = $"+{distance.Value - distance.Bonus}";


    }

  
   
}

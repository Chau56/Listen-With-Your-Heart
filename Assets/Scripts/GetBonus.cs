using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetBonus : MonoBehaviour
{
    private Text text;
    [SerializeField]
    private Distance distance;

    private void Start()
    {
        text = GetComponent<Text>();
        GameEvents.instance.GameWin += Renew;
    }

    private void Renew()
    {
        text.text = $"+{distance.Bonus}";
    }
}

using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class AutoJump : MonoBehaviour
{
    private GameEvents events;
    [SerializeField]
    [Tooltip("�����Ծ����")]
    private float randomProbability = 0.01f;//�漴��Ծ����
    [SerializeField]
    [Tooltip("�����Ծʱ�䣬��λ����")]
    private int randomTime = 1000;//�漴��Ծ����

    private void Start()
    {
        events = GameEvents.instance;
    }

    private void FixedUpdate()
    {
        if (Random.value < randomProbability)
        {
            events.StartJump1();
            _ = FinishJump(events.FinishJump1);
        }
        if (Random.value < randomProbability)
        {
            events.StartJump2();
            _ = FinishJump(events.FinishJump2);
        }
    }

    private async Task FinishJump(Func<bool> func)
    {
        await Task.Delay(randomTime);
        func();
    }
}


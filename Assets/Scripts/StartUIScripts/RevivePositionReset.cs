using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePositionReset : MonoBehaviour
{
    private GameEvents events;
    void Start()
    {
        events = GameEvents.instance;
        events.GameFailed += ()=>StartCoroutine(Restart());
    }
    private IEnumerator Restart()
    {
        Debug.Log("game failed");
        yield return new WaitForSecondsRealtime(1.2f);
            events.ClearState();
            events.StartGame();

    }
}

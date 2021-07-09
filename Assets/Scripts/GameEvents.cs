using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action GameFailed, GamePause, GameResume;
    [SerializeField]
    private DeathLogic player1;
    private bool p1Dead;
    [SerializeField]
    private DeathLogic player2;
    private bool p2Dead;

    // Start is called before the first frame update
    private void Start()
    {
        RegisterSelfEvents();
        RegisterInputEvents();
    }

    private void OnDestroy()
    {
        RevokeSelfEvents();
        RevokeInputEvents();
    }

    private void RegisterSelfEvents()
    {
        player1.OnDied += CheckBlackFailed;
        player2.OnDied += CheckWhiteFailed;
        GameFailed += Log;
    }

    private void RegisterInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause += InvokePause;
        input.Resume += InvokeResume;
    }

    private void RevokeInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause -= InvokePause;
        input.Resume -= InvokeResume;
    }

    private void InvokePause()
    {
        GamePause();
    }

    private void InvokeResume()
    {
        GameResume();
    }

    private void RevokeSelfEvents()
    {
        GameFailed = () => { };
    }

    private void Log()
    {
        Debug.Log("Game failed.");
    }

    private void CheckBlackFailed()
    {
        p1Dead = true;
        CheckFailed();
    }

    private void CheckWhiteFailed()
    {
        p2Dead = true;
        CheckFailed();
    }

    private void CheckFailed()
    {
        if (p1Dead && p2Dead)
        {
            GameFailed();
        }
    }
}

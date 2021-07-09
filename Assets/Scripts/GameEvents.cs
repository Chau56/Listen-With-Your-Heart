using System;
using GameHardware;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action GameFailed, GamePause, GameResume, Jump1Start, Jump2Start, Jump1Finished, Jump2Finished;
    [SerializeField]
    private DeathLogic player1;
    private bool p1Dead;
    [SerializeField]
    private DeathLogic player2;
    private bool p2Dead;
    private bool gameFailed, gamePaused;

    // Start is called before the first frame update
    private void Start()
    {
        RegisterSelfEvents();
        RegisterInputEvents();
    }

    private void OnDestroy()
    {
        RevokeInputEvents();
    }

    private void RegisterSelfEvents()
    {
        player1.OnDied += CheckBlackFailed;
        player2.OnDied += CheckWhiteFailed;
        GameFailed += RegisterGameFailed;
        GamePause += RegisterGamePaused;
        GameResume += RegisterGameResume;
    }

    private void RegisterGameFailed()
    {
        gameFailed = true;
    }

    private void RegisterGamePaused()
    {
        gamePaused = true;
        Jump1Finished();
        Jump2Finished();
    }

    private void RegisterGameResume()
    {
        gamePaused = false;
    }

    private void RegisterInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause += InvokePause;
        input.Resume += InvokeResume;
        input.Jump1Start += InvokeJump1;
        input.Jump1Finished += FinishJump1;
        input.Jump2Start += InvokeJump2;
        input.Jump2Finished += FinishJump2;
    }

    private void RevokeInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause -= InvokePause;
        input.Resume -= InvokeResume;
        input.Jump1Start -= InvokeJump1;
        input.Jump1Finished -= FinishJump1;
        input.Jump2Start -= InvokeJump2;
        input.Jump2Finished -= FinishJump2;
    }

    private void DoOnNotFinished(Action action)
    {
        if (!gameFailed) action();
    }
    private void DoOnNotPaused(Action action)
    {
        if (!(gamePaused || gameFailed)) action();
    }

    private void InvokePause()
    {
        DoOnNotFinished(GamePause);
    }

    private void InvokeResume()
    {
        DoOnNotFinished(GameResume);
    }

    private void InvokeJump1()
    {
        DoOnNotPaused(Jump1Start);
    }

    private void InvokeJump2()
    {
        DoOnNotPaused(Jump2Start);
    }

    private void FinishJump1()
    {
        DoOnNotPaused(Jump1Finished);
    }

    private void FinishJump2()
    {
        DoOnNotPaused(Jump2Finished);
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
        Debug.Log("check game failed");
        if (p1Dead && p2Dead)
        {
            gameFailed = true;
            Debug.Log("Game failed.");
            GameFailed();
        }
    }
}

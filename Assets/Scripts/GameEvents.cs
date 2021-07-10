using System;
using System.Collections;
using GameHardware;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action GameStart, GameFailed, GameWin, GamePause, GameResume, Jump1Start, Jump2Start, Jump1Finished, Jump2Finished;
    [SerializeField]
    private DeathLogic player1;
    private bool p1Dead;
    [SerializeField]
    private DeathLogic player2;
    private bool p2Dead;
    private bool gameEnd, gamePaused;
    [SerializeField]
    private CubeDetection endline;
    [SerializeField]
    [Tooltip("游戏延迟多长时间后才开始。单位秒")]
    private float delay = 1;

    // Start is called before the first frame update
    private void Start()
    {
        gameEnd = true;
        RegisterSelfEvents();
        RegisterInputEvents();
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSecondsRealtime(delay);
        BeforeStart();
        yield return new WaitForEndOfFrame();
        GameStart();
    }

    private void BeforeStart()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        RevokeInputEvents();
    }

    private void RegisterSelfEvents()
    {
        player1.OnDied += CheckBlackFailed;
        player2.OnDied += CheckWhiteFailed;
        endline.OnHitEndline += () => GameWin();
        GameFailed += RegisterGameFailed;
        GamePause += RegisterGamePaused;
        GameResume += RegisterGameResume;
        GameStart += RegisterGameStart;
        GameWin += RegisterGameWin;
    }

    private void RegisterGameStart()
    {
        Debug.Log("game start");
        gameEnd = false;
    }

    private void RegisterGameFailed()
    {
        Debug.Log("game failed");
        gameEnd = true;
    }

    private void RegisterGameWin()
    {
        Debug.Log("game win");
        GamePause();
        gameEnd = true;
    }

    private void RegisterGamePaused()
    {
        Debug.Log("game paused");
        gamePaused = true;
        Jump1Finished();
        Jump2Finished();
    }

    private void RegisterGameResume()
    {
        Debug.Log("game resumed");
        gamePaused = false;
    }
    #region Input Area
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
    #endregion
    private void DoOnNotFinished(Action action)
    {
        if (!gameEnd) action();
    }
    
    private void DoOnNotPaused(Action action)
    {
        if (!(gamePaused || gameEnd)) action();
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
            gameEnd = true;
            Debug.Log("Game failed.");
            GameFailed();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}

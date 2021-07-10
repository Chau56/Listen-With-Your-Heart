using System;
using System.Collections;
using GameHardware;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public event Action
        GameStart, GameFailed, GameWin, GamePause, GameResume,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackWillRevive, WhiteWillRevive;
    [SerializeField]
    private DeathLogic player1;
    private bool p1Dead, p1Jumped;
    [SerializeField]
    private DeathLogic player2;
    private bool p2Dead, p2Jumped;
    private bool gameNotEnd, gamePaused;
    [SerializeField]
    private EndlineDetection endline;
    [SerializeField]
    [Tooltip("游戏延迟多长时间后才开始。单位秒")]
    private float startDelay = 1;
    [SerializeField]
    [Tooltip("游戏延迟多长时间后才结束。单位秒")]
    private float endDelay = 1;
    private Vector2 gravity;

    // Start is called before the first frame update
    private void Start()
    {
        gravity = Physics2D.gravity;
        RegisterSelfEvents();
        RegisterInputEvents();
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        BeforeStart();
        yield return new WaitForEndOfFrame();
        GameStart();
    }

    private void BeforeStart()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
    }

    private void RegisterSelfEvents()
    {
        player1.OnDied += CheckBlackFailed;
        player2.OnDied += CheckWhiteFailed;
        player1.OnHitRevive += ReviveWhite;
        player2.OnHitRevive += ReviveBlack;
        endline.OnHitEndline += HitEndline;
        GameFailed += RegisterGameFailed;
        GamePause += RegisterGamePaused;
        GameResume += RegisterGameResume;
        GameStart += RegisterGameStart;
        GameWin += RegisterGameWin;
    }

    private void HitEndline()
    {
        Debug.Log(nameof(HitEndline));
        GameWin();
    }

    private void RegisterGameStart()
    {
        Debug.Log("game start");
        gameNotEnd = true;
    }

    private void RegisterGameFailed()
    {
        Debug.Log("game failed");
        gameNotEnd = false;
    }

    private void RegisterGameWin()
    {
        Debug.Log("game win");
        gameNotEnd = false;
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

    private void InvokePause()
    {
        if (gameNotEnd && !gamePaused)
        {
            Physics2D.gravity = Vector2.zero;
            GamePause();
        }
    }

    private void InvokeResume()
    {
        if (gameNotEnd && gamePaused)
        {
            Physics2D.gravity = gravity;
            GameResume();
        }
    }

    private void InvokeJump1()
    {
        if (!(p1Jumped || gamePaused || p1Dead) && gameNotEnd)
        {
            p1Jumped = true;
            Jump1Start();
        }
    }

    private void InvokeJump2()
    {
        if (!(p2Jumped || gamePaused || p2Dead) && gameNotEnd)
        {
            p2Jumped = true;
            Jump2Start();
        }
    }

    private void FinishJump()
    {
        if (!gamePaused)
        {
            if (p1Jumped && !p1Dead)
            {
                p1Jumped = false;
                Jump1Finished();
            }
            else if (p2Jumped && !p2Dead)
            {
                p2Jumped = false;
                Jump2Finished();
            }
        }
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
        if (p1Dead && p2Dead && gameNotEnd && !gamePaused)
        {
            gameNotEnd = false;
            Debug.Log("Game failed.");
            GameFailed();
            StartCoroutine(RestartScene());
        }
    }

    private void ReviveBlack()
    {
        Debug.Log("black will revive.");
        p1Dead = false;
        BlackWillRevive();
    }

    private void ReviveWhite()
    {
        Debug.Log("white will revive.");
        p2Dead = false;
        WhiteWillRevive();
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("app paused");
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    private IEnumerator RestartScene()
    {
        Debug.Log(nameof(RestartScene));
        yield return new WaitForSecondsRealtime(endDelay);
        SceneManager.LoadSceneAsync(0);
    }

    #region Input Area
    private void RegisterInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause += InvokePause;
        input.Resume += InvokeResume;
        input.Jump1Start += InvokeJump1;
        input.Jump1Finished += FinishJump;
        input.Jump2Start += InvokeJump2;
        input.Jump2Finished += FinishJump;
    }

    private void RevokeInputEvents()
    {
        var input = InGameActionDistribute.instance;
        input.Pause -= InvokePause;
        input.Resume -= InvokeResume;
        input.Jump1Start -= InvokeJump1;
        input.Jump1Finished -= FinishJump;
        input.Jump2Start -= InvokeJump2;
        input.Jump2Finished -= FinishJump;
    }

    private void OnDestroy()
    {
        Debug.Log("game events destroyed");
        RevokeInputEvents();
    }

    private void OnApplicationQuit()
    {
        gameNotEnd = false;
    }
    #endregion
}

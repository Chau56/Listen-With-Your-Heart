using System;
using UnityEngine;

public class GameEvents
{
    public static GameEvents instance = new GameEvents();
    public event Action
        GameStart, GameFailed, GameWin, GamePause, GameResume, GameAbnormalEnd,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackReviving, WhiteReviving, BlackDying, WhiteDying,
        BlackProcessStart, WhiteProcessStart, BlackProcessEnd, WhiteProcessEnd;

    /// <summary>
    /// 黑色状态变量
    /// </summary>
    private bool p1Dead, p1Jumped;
    /// <summary>
    /// 白色状态变量
    /// </summary>
    private bool p2Dead, p2Jumped;
    /// <summary>
    /// 游戏状态变量
    /// </summary>
    private bool gameNotEnd, gamePaused;

    public void KillBlack()
    {
        if (!(p1Dead || gamePaused) && gameNotEnd)
        {
            p1Dead = true;
            BlackProcessEnd();
            BlackDying();
            CheckGameFailed();
        }
    }

    public void KillWhite()
    {
        if (!(p2Dead || gamePaused) && gameNotEnd)
        {
            p2Dead = true;
            WhiteProcessEnd();
            WhiteDying();
            CheckGameFailed();
        }
    }

    public void HitEndline()
    {
        if (gameNotEnd && !gamePaused)
        {
            gameNotEnd = false;
            StopTwoProgress();
            GameWin();
        }
    }

    public void ReviveBlack()
    {
        if (gameNotEnd && p1Dead && !gamePaused)
        {
            p1Dead = false;
            BlackProcessStart();
            BlackReviving();
        }
    }

    public void ReviveWhite()
    {
        if (gameNotEnd && p2Dead && !gamePaused)
        {
            p2Dead = false;
            WhiteProcessStart();
            WhiteReviving();
        }
    }

    public void StartJump1()
    {
        Debug.Log("start jp1 trigger");
        if (!(p1Jumped || p1Dead || gamePaused))
        {
            p1Jumped = true;
            Jump1Start();
        }
    }

    public void FinishJump1()
    {
        Debug.Log("finish jp1 trigger");
        if (!(gamePaused || p1Dead) && p1Jumped)
        {
            p1Jumped = false;
            Jump1Finished();
        }
    }

    public void StartJump2()
    {
        Debug.Log("start jp2 trigger");
        if (!(p2Jumped || gamePaused || p2Dead))
        {
            p2Jumped = true;
            Jump2Start();
        }
    }

    public void FinishJump2()
    {
        Debug.Log("finish jp2 trigger");
        if (!(gamePaused || p2Dead) && p2Jumped)
        {
            p2Jumped = false;
            Jump2Finished();
        }
    }

    public void StartGame()
    {
        gameNotEnd = true;
        GameStart();
        StartTwoProgress();
    }

    public void EndGame(bool win)
    {
        gameNotEnd = false;
        StopTwoProgress();
        if (win) GameWin();
        else GameFailed();
    }

    public void EndGame()
    {
        gameNotEnd = false;
        GameAbnormalEnd();
    }

    /// <summary>
    /// pause会立即停止跳跃。
    /// </summary>
    public void PauseGame()
    {
        if (gameNotEnd && !gamePaused)
        {
            FinishJump1();
            FinishJump2();
            gamePaused = true;
            StopTwoProgress();
            GamePause();
        }
    }

    public void ResumeGame()
    {
        if (gameNotEnd && gamePaused)
        {
            gamePaused = false;
            StartTwoProgress();
            GameResume();
        }
    }
    // Start is called before the first frame update
    private GameEvents()
    {
        ClearEvents();
    }

    public void ClearEvents()
    {
        BlackProcessStart =
        BlackProcessEnd =
        WhiteProcessStart =
        WhiteProcessEnd =
        GameStart =
        GameFailed =
        GameWin =
        GameAbnormalEnd =
        GamePause =
        GameResume =
        Jump1Start =
        Jump2Start =
        Jump1Finished =
        Jump2Finished =
        BlackReviving =
        WhiteReviving =
        BlackDying =
        WhiteDying =
        NullMethod;
    }

    private void NullMethod()
    {
    }

    public void ClearState()
    {
        p1Dead = p2Dead = p1Jumped = p2Jumped = gameNotEnd = gamePaused = false;
    }

    private void CheckGameFailed()
    {
        if (p1Dead && p2Dead)
        {
            gameNotEnd = false;
            GameFailed();
        }
    }

    private void StopTwoProgress()
    {
        if (!p1Dead) BlackProcessEnd();
        if (!p2Dead) WhiteProcessEnd();
    }

    private void StartTwoProgress()
    {
        if (!p1Dead) BlackProcessStart();
        if (!p2Dead) WhiteProcessStart();
    }
}

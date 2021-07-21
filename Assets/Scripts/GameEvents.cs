///<summary>
///作者：周权
///创建日期：2021-7-8
///最新修改日期：2021-7-16
///</summary>


using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameEvents
{
    public static GameEvents instance = new GameEvents();
    public event Action GameBeforeAwake, GameRestart,
        GameAwake, GameStart, GameFailed, GameWin, GamePause, GameResume, GameEnd, GameAbnormalEnd,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackReviving, WhiteReviving, BlackDying, WhiteDying,
        BlackWillDie, WhiteWillDie,
        BlackProcessStart, WhiteProcessStart, BlackProcessEnd, WhiteProcessEnd;
    public int BlackRevive
    {
        get; private set;
    }
    public int WhiteRevive
    {
        get; private set;
    }
    private bool behold;
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

    public bool KillBlack()
    {
        if (!(p1Dead || gamePaused) && gameNotEnd)
        {
            FinishJump1();
            p1Dead = true;
            BlackProcessEnd();
            BlackWillDie();
            BlackDying();
            CheckGameFailed();
            return true;
        }
        return false;
    }

    public bool KillWhite()
    {
        if (!(p2Dead || gamePaused) && gameNotEnd)
        {
            FinishJump2();
            p2Dead = true;
            WhiteProcessEnd();
            WhiteWillDie();
            WhiteDying();
            CheckGameFailed();
            return true;
        }
        return false;
    }

    public bool HitEndline()
    {
        if (gameNotEnd && !gamePaused)
        {
            gameNotEnd = false;
            StopTwoProgress();
            GameWin();
            GameEnd();
            return true;
        }
        return false;
    }

    public bool ReviveBlack()
    {
        if (gameNotEnd && p1Dead && !gamePaused)
        {
            p1Dead = false;
            BlackProcessStart();
            BlackReviving();
            BlackRevive += 1;
            return true;
        }
        return false;
    }

    public bool ReviveWhite()
    {
        if (gameNotEnd && p2Dead && !gamePaused)
        {
            p2Dead = false;
            WhiteProcessStart();
            WhiteReviving();
            WhiteRevive += 1;
            return true;
        }
        return false;
    }

    public bool StartJump1()
    {
        Debug.Log("start jp1 trigger");
        if (!(p1Jumped || p1Dead || gamePaused))
        {
            p1Jumped = true;
            Jump1Start();
            return true;
        }
        return false;
    }

    public bool FinishJump1()
    {
        Debug.Log("finish jp1 trigger");
        if (!(gamePaused || p1Dead) && p1Jumped)
        {
            p1Jumped = false;
            Jump1Finished();
            return true;
        }
        return false;
    }

    public bool StartJump2()
    {
        Debug.Log("start jp2 trigger");
        if (!(p2Jumped || gamePaused || p2Dead))
        {
            p2Jumped = true;
            Jump2Start();
            return true;
        }
        return false;
    }

    public bool FinishJump2()
    {
        Debug.Log("finish jp2 trigger");
        if (!(gamePaused || p2Dead) && p2Jumped)
        {
            p2Jumped = false;
            Jump2Finished();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 可以在未结束时强制启动游戏, 这将结束游戏
    /// </summary>
    /// <param name="delay">毫秒延迟</param>
    public async Task StartGame(int beforeStartDelay, int startDelay, int endDelay, CancellationToken token = default)
    {
        if (behold) return;
        Debug.Log($"game events start game {behold}");
        behold = true;
        try
        {
            EndGame();
            await Task.Delay(endDelay, token);
            ClearState();
            GameBeforeAwake();
            await Task.Delay(beforeStartDelay, token);
            GameAwake();
            await Task.Delay(startDelay, token);
            GameStart();
            gameNotEnd = true;
            StartTwoProgress();
            behold = false;
            //startMutex.ReleaseMutex();
        }
        catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
        {
            behold = false;
            //startMutex.ReleaseMutex();
        }
    }

    public bool EndGame(bool win)
    {
        if (!gameNotEnd)
        {
            GameRestart();
            return false;
        }
        StopTwoProgress();
        gameNotEnd = false;
        if (win) GameWin();
        else GameFailed();
        GameEnd();
        return true;
    }

    public bool EndGame()
    {
        if (!gameNotEnd)
        {
            GameRestart();
            return false;
        }
        StopTwoProgress();
        gameNotEnd = false;
        GameAbnormalEnd();
        GameEnd();
        return true;
    }

    /// <summary>
    /// pause会立即停止跳跃。
    /// </summary>
    public bool PauseGame()
    {
        if (gameNotEnd && !gamePaused)
        {
            FinishJump1();
            FinishJump2();
            gamePaused = true;
            StopTwoProgress();
            GamePause();
            return true;
        }
        return false;
    }

    public bool ResumeGame()
    {
        if (gameNotEnd && gamePaused)
        {
            gamePaused = false;
            StartTwoProgress();
            GameResume();
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    private GameEvents()
    {
        ClearEvents();
    }

    public void ClearEvents()
    {
        GameRestart =
        BlackWillDie =
        WhiteWillDie =
        GameBeforeAwake =
        GameAbnormalEnd =
        GameAwake =
        BlackProcessStart =
        BlackProcessEnd =
        WhiteProcessStart =
        WhiteProcessEnd =
        GameStart =
        GameFailed =
        GameWin =
        GameEnd =
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
        BlackRevive = WhiteRevive = 0;
    }

    private void CheckGameFailed()
    {
        if (p1Dead && p2Dead)
        {
            EndGame(false);
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

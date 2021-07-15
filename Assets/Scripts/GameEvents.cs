using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameEvents
{
    public static GameEvents instance = new GameEvents();
    public event Action
        GameAwake, GameStart, GameFailed, GameWin, GamePause, GameResume, GameEnd, GameAbnormalEnd,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackReviving, WhiteReviving, BlackDying, WhiteDying,
        BlackProcessStart, WhiteProcessStart, BlackProcessEnd, WhiteProcessEnd;
    private bool behold;
    /// <summary>
    /// ��ɫ״̬����
    /// </summary>
    private bool p1Dead, p1Jumped;
    /// <summary>
    /// ��ɫ״̬����
    /// </summary>
    private bool p2Dead, p2Jumped;
    /// <summary>
    /// ��Ϸ״̬����
    /// </summary>
    private bool gameNotEnd, gamePaused;

    public bool KillBlack()
    {
        if (!(p1Dead || gamePaused) && gameNotEnd)
        {
            FinishJump1();
            p1Dead = true;
            BlackProcessEnd();
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
    /// ������δ����ʱǿ��������Ϸ, �⽫������Ϸ
    /// </summary>
    /// <param name="delay">�����ӳ�</param>
    public async Task StartGame(int startDelay, int endDelay, CancellationToken token = default)
    {
        if (behold) return;
        Debug.Log($"game events start game {behold}");
        behold = true;
        try
        {
            EndGame();
            await Task.Delay(endDelay, token);
            ClearState();
            GameAwake();
            await Task.Delay(startDelay, token);
            gameNotEnd = true;
            GameStart();
            StartTwoProgress();
            behold = false;
            //startMutex.ReleaseMutex();
        }
        catch (TaskCanceledException)
        {
            behold = false;
            //startMutex.ReleaseMutex();
        }
    }

    public bool EndGame(bool win)
    {
        if (!gameNotEnd) return false;
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
            return false;
        }
        StopTwoProgress();
        gameNotEnd = false;
        GameAbnormalEnd();
        GameEnd();
        return true;
    }

    /// <summary>
    /// pause������ֹͣ��Ծ��
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

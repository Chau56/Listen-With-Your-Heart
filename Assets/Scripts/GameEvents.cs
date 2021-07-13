using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents
{
    public static GameEvents instance = new GameEvents();
    public event Action
        GameStart, GameFailed, GameWin, GamePause, GameResume,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackReviving, WhiteReviving, BlackDying, WhiteDying;
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
    private Vector2 gravity;

    public void KillBlack()
    {
        if (!(p1Dead || gamePaused) && gameNotEnd)
        {
            p1Dead = true;
            BlackDying();
            CheckGameFailed();
        }
    }

    public void KillWhite()
    {
        if (!(p2Dead || gamePaused) && gameNotEnd)
        {
            p2Dead = true;
            WhiteDying();
            CheckGameFailed();
        }
    }

    public void HitEndline()
    {
        if (gameNotEnd && !gamePaused)
        {
            gameNotEnd = false;
            GameWin();
        }
    }

    public void ReviveBlack()
    {
        if (gameNotEnd && p1Dead && !gamePaused)
        {
            p1Dead = false;
            BlackReviving();
        }
    }

    public void ReviveWhite()
    {
        if (gameNotEnd && p2Dead && !gamePaused)
        {
            p2Dead = false;
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

    public async Task WaitToStart(int startDelay)
    {
        Debug.Log("wait to start");
        Physics2D.gravity = Vector2.zero;
        await Task.Delay(startDelay);
        Physics2D.gravity = gravity;
        gameNotEnd = true;
        GameStart();
    }

    public async Task RestartScene(int endDelay)
    {
        Debug.Log("restart scene");
        await Task.Delay(endDelay);
        ClearEvents();
        ClearState();
        SceneManager.LoadSceneAsync(0);
    }

    public Vector2 Gravity
    {
        get => gravity;
        set => gravity = value;
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
            Physics2D.gravity = Vector2.zero;
            GamePause();
        }
    }

    public void ResumeGame()
    {
        if (gameNotEnd && gamePaused)
        {
            gamePaused = false;
            Physics2D.gravity = gravity;
            GameResume();
        }
    }

    public void EndGame()
    {
        gameNotEnd = false;
    }
    // Start is called before the first frame update
    private GameEvents()
    {
        ClearEvents();
    }

    private void ClearEvents()
    {
        GameStart = () => Debug.Log("game start");
        GameFailed = () => Debug.Log("game failed");
        GameWin = () => Debug.Log("game win");
        GamePause = () => Debug.Log("game paused");
        GameResume = () => Debug.Log("game resumed");
        Jump1Start = () => Debug.Log("jump1 start");
        Jump2Start = () => Debug.Log("jump2 start");
        Jump1Finished = () => Debug.Log("jump1 finished");
        Jump2Finished = () => Debug.Log("jump2 finished");
        BlackReviving = () => Debug.Log("black revive");
        WhiteReviving = () => Debug.Log("white revive");
        BlackDying = () => Debug.Log("black die");
        WhiteDying = () => Debug.Log("white die");
    }

    private void ClearState()
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

}

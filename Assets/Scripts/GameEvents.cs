using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
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
    [SerializeField]
    [Tooltip("场景加载完成后过多久调用GameStart。单位秒")]
    private float startDelay = 1;
    [SerializeField]
    [Tooltip("GameFailed多久后重加载场景。单位秒")]
    private float endDelay = 1;
    private Vector2 gravity;
    private Pointer currentPointer;
    private float halfScreen;

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

    /// <summary>
    /// pause会立即停止跳跃。
    /// </summary>
    public void OnPause()
    {
        if (gameNotEnd)
        {
            if (gamePaused)
            {
                gamePaused = false;
                Physics2D.gravity = gravity;
                GameResume();
            }
            else
            {
                if (p1Jumped)
                {
                    p1Jumped = false;
                    Jump1Finished();
                }
                if (p2Jumped)
                {
                    p2Jumped = false;
                    Jump2Finished();
                }
                gamePaused = true;
                Physics2D.gravity = Vector2.zero;
                GamePause();
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        halfScreen = (float)Screen.height / 2;
        gravity = Physics2D.gravity;
        currentPointer = Pointer.current;
        RegisterSelfEvents();
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        Physics2D.gravity = Vector2.zero;
        yield return new WaitForSecondsRealtime(startDelay);
        Physics2D.gravity = gravity;
        gameNotEnd = true;
        GameStart();
    }

    private void RegisterSelfEvents()
    {
        GameStart += () => Debug.Log("game start");
        GameFailed += () => Debug.Log("game failed");
        GameWin += () => Debug.Log("game win");
        GamePause += () => Debug.Log("game paused");
        GameResume += () => Debug.Log("game resumed");
        Jump1Start += () => Debug.Log("jump1 start");
        Jump2Start += () => Debug.Log("jump2 start");
        Jump1Finished += () => Debug.Log("jump1 finished");
        Jump2Finished += () => Debug.Log("jump2 finished");
        BlackReviving += () => Debug.Log("black revive");
        WhiteReviving += () => Debug.Log("white revive");
        BlackDying += () => Debug.Log("black die");
        WhiteDying += () => Debug.Log("white die");
    }

    private void CheckGameFailed()
    {
        if (p1Dead && p2Dead)
        {
            gameNotEnd = false;
            GameFailed();
            StartCoroutine(RestartScene());
        }
    }

    private void OnJump1Started()
    {
        if (!(p1Jumped || p1Dead || gamePaused))
        {
            p1Jumped = true;
            Jump1Start();
        }
    }

    private void OnJump1Finished()
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

    private void OnJump2Started()
    {
        if (!(p2Jumped || gamePaused || p2Dead))
        {
            p2Jumped = true;
            Jump2Start();
        }
    }

    private void OnJump2Finished()
    {
        if (!gamePaused)
        {
            if (p2Jumped && !p2Dead)
            {
                p2Jumped = false;
                Jump2Finished();
            }
            else if (p1Jumped && !p1Dead)
            {
                p1Jumped = false;
                Jump1Finished();
            }
        }
    }

    private void OnJumpStarted()
    {
        float y = currentPointer.position.y.ReadValue();
        Debug.Log($"jump start {y}");
        if (y < halfScreen)
        {
            OnJump1Started();
        }
        else
        {
            OnJump2Started();
        }
    }

    private void OnJumpFinished()
    {
        float y = currentPointer.position.y.ReadValue();
        Debug.Log($"jump finish {y}");
        if (y < halfScreen)
        {
            OnJump1Finished();
        }
        else
        {
            OnJump2Finished();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("app pause");
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("app resume");
            Time.timeScale = 1;
        }
    }

    private IEnumerator RestartScene()
    {
        Debug.Log(nameof(RestartScene));
        yield return new WaitForSecondsRealtime(endDelay);
        //Physics2D.gravity = gravity;
        SceneManager.LoadSceneAsync(0);
    }

    private void OnApplicationQuit()
    {
        gameNotEnd = false;
    }

}

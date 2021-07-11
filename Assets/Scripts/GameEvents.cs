using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public event Action
        GameStart, GameFailed, GameWin, GamePause, GameResume,
        Jump1Start, Jump2Start, Jump1Finished, Jump2Finished,
        BlackWillRevive, WhiteWillRevive, BlackDied, WhiteDied;
    [SerializeField]
    private DeathLogic player1;
    /// <summary>
    /// 黑色状态变量
    /// </summary>
    private bool p1Dead, p1Jumped;
    [SerializeField]
    private DeathLogic player2;
    /// <summary>
    /// 白色状态变量
    /// </summary>
    private bool p2Dead, p2Jumped;
    /// <summary>
    /// 游戏状态变量
    /// </summary>
    private bool gameNotEnd, gamePaused;
    [SerializeField]
    private EndlineDetection endline;
    [SerializeField]
    [Tooltip("场景加载完成后过多久调用GameStart。单位秒")]
    private float startDelay = 1;
    [SerializeField]
    [Tooltip("GameFailed多久后重加载场景。单位秒")]
    private float endDelay = 1;
    private Vector2 gravity;
    private Pointer current;
    private float halfScreen;

    // Start is called before the first frame update
    private void Start()
    {
        halfScreen = (float)Screen.height / 2;
        gravity = Physics2D.gravity;
        current = Pointer.current;
        RegisterSelfEvents();
        RegisterOtherEvents();
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        BeforeStart();
        yield return new WaitForEndOfFrame();
        gameNotEnd = true;
        GameStart();
    }

    private void BeforeStart()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
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
        BlackWillRevive += () => Debug.Log("black will revive");
        WhiteWillRevive += () => Debug.Log("white will revive");
        BlackDied += () => Debug.Log("black died");
        WhiteDied += () => Debug.Log("white died");
    }

    private void RegisterOtherEvents()
    {
        player1.OnDied += BlackFailed;
        player2.OnDied += WhiteFailed;
        player1.OnHitRevive += ReviveWhite;
        player2.OnHitRevive += ReviveBlack;
        endline.OnHitEndline += HitEndline;
    }

    private void BlackFailed()
    {
        BlackDied();
        p1Dead = true;
        CheckGameFailed();
    }

    private void WhiteFailed()
    {
        WhiteDied();
        p2Dead = true;
        CheckGameFailed();
    }

    private void CheckGameFailed()
    {
        if (p1Dead && p2Dead && gameNotEnd)
        {
            gameNotEnd = false;
            GameFailed();
            StartCoroutine(RestartScene());
        }
    }

    private void ReviveWhite()
    {
        if (gameNotEnd && p2Dead)
        {
            p2Dead = false;
            WhiteWillRevive();
        }
    }

    private void ReviveBlack()
    {
        if (gameNotEnd && p1Dead)
        {
            p1Dead = false;
            BlackWillRevive();
        }
    }

    private void HitEndline()
    {
        if (gameNotEnd)
        {
            gameNotEnd = false;
            GameWin();
        }
    }

    /// <summary>
    /// pause会立即停止跳跃。
    /// </summary>
    private void OnPause()
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

    private void OnJump1Started()
    {
        if (!(p1Jumped || p1Dead || gamePaused) && gameNotEnd)
        {
            p1Jumped = true;
            Jump1Start();
        }
    }

    private void OnJump1Finished()
    {
        if (!gamePaused && gameNotEnd)
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
        if (!(p2Jumped || gamePaused || p2Dead) && gameNotEnd)
        {
            p2Jumped = true;
            Jump2Start();
        }
    }

    private void OnJump2Finished()
    {
        if (!gamePaused && gameNotEnd)
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
        float y = current.position.y.ReadValue();
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
        float y = current.position.y.ReadValue();
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
        SceneManager.LoadSceneAsync(0);
    }

    #region Input Area
    //private void RegisterInputEvents()
    //{
    //    var input = InGameActionDistribute.instance;
    //    input.Pause += InvokePause;
    //    input.Resume += InvokeResume;
    //    input.Jump1Start += InvokeJump1;
    //    input.Jump1Finished += FinishJump;
    //    input.Jump2Start += InvokeJump2;
    //    input.Jump2Finished += FinishJump;
    //}

    //private void RevokeInputEvents()
    //{
    //    var input = InGameActionDistribute.instance;
    //    input.Pause -= InvokePause;
    //    input.Resume -= InvokeResume;
    //    input.Jump1Start -= InvokeJump1;
    //    input.Jump1Finished -= FinishJump;
    //    input.Jump2Start -= InvokeJump2;
    //    input.Jump2Finished -= FinishJump;
    //}

    //private void OnDestroy()
    //{
    //    Debug.Log("game events destroyed");
    //    RevokeInputEvents();
    //}
    #endregion

    private void OnApplicationQuit()
    {
        gameNotEnd = false;
    }

}

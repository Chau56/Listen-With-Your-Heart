using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicBehavior : MonoBehaviour
{
    private GameEvents events;
    private Vector2 gravity;
    [SerializeField]
    [Tooltip("开始游戏前的延迟。单位毫秒")]
    private int startDelay = 850;
    [SerializeField]
    [Tooltip("游戏结束后的延迟。单位毫秒")]
    private int endDelay = 850;
    [SerializeField]
    [Tooltip("菜单界面索引")]
    private int menu = 0;
    [SerializeField]
    [Tooltip("游戏界面索引")]
    private int game = 1;
    private bool restartPressed;
    private bool menuPressed;
    [SerializeField]
    private Transform revivePoint;
    [SerializeField]
    private Transform endline;
    private float startPosition;
    private float totalLen;

    private void Start()
    {
        events = GameEvents.instance;
        gravity = Physics2D.gravity;
        startPosition = revivePoint.position.x;
        totalLen = endline.position.x - startPosition;
        RegisterEvents();
        AddDebugEvents();
        _ = WaitToStart();
    }

    public int Progress
    {
        get
        {
            return Mathf.FloorToInt((revivePoint.position.x - startPosition) / totalLen);
        }
    }

    public void Restart()
    {
        if (!restartPressed)
        {
            restartPressed = true;
            events.EndGame();
            RestartGame();
        }
    }

    public void Resume()
    {
        events.ResumeGame();
    }

    public void LoadMenu()
    {
        if (!menuPressed)
        {
            menuPressed = true;
            events.EndGame();
            _ = LoadScene(menu, endDelay);
        }
    }

    private void RegisterEvents()
    {
        events.GameFailed += RestartGame;
        events.GameFailed += Clear;
        events.GameWin += Clear;
        events.GameAbnormalEnd += Clear;
        events.GamePause += PauseGravity;
        events.GameResume += ResumeGravity;
    }

    private void Clear()
    {
        events.ClearEvents();
        events.ClearState();
    }

    private void RestartGame()
    {
        _ = LoadScene(game, endDelay);
    }

    private void AddDebugEvents()
    {
        events.GameStart += () => Debug.Log("game start");
        events.GameFailed += () => Debug.Log("game failed");
        events.GameWin += () => Debug.Log("game win");
        events.GamePause += () => Debug.Log("game paused");
        events.GameResume += () => Debug.Log("game resumed");
        events.Jump1Start += () => Debug.Log("jump1 start");
        events.Jump2Start += () => Debug.Log("jump2 start");
        events.Jump1Finished += () => Debug.Log("jump1 finished");
        events.Jump2Finished += () => Debug.Log("jump2 finished");
        events.BlackReviving += () => Debug.Log("black revive");
        events.WhiteReviving += () => Debug.Log("white revive");
        events.BlackDying += () => Debug.Log("black die");
        events.WhiteDying += () => Debug.Log("white die");
    }

    private async Task WaitToStart()
    {
        Debug.Log("wait to start");
        Physics2D.gravity = Vector2.zero;
        await Task.Delay(startDelay);
        Physics2D.gravity = gravity;
        events.StartGame();
    }


    private void ResumeGravity()
    {
        Physics2D.gravity = gravity;
    }

    private void PauseGravity()
    {
        Physics2D.gravity = Vector2.zero;
    }

    private async Task LoadScene(int index, int delay)
    {
        await Task.Delay(delay);
        Physics2D.gravity = gravity;
        Debug.Log($"load scene {index}");
        SceneManager.LoadSceneAsync(index);
    }

    private void OnApplicationQuit()
    {
        events.EndGame(false);
    }

}

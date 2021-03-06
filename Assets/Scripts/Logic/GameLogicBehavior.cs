///<summary>
///作者：张翔宇
///创建日期：2021-7-13
///更新者：周权
///最新修改日期：2021-7-16
///</summary>


using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicBehavior : MonoBehaviour
{
    private GameEvents events;
    private Vector2 gravity;
    [SerializeField]
    [Tooltip("唤醒游戏前的延迟。单位毫秒")]
    private int beforeStartDelay = 850;
    [SerializeField]
    [Tooltip("开始游戏前的延迟。单位毫秒")]
    private int startDelay = 850;
    [SerializeField]
    [Tooltip("游戏结束后的延迟。单位毫秒")]
    private int endDelay = 850;
    [SerializeField]
    [Tooltip("菜单界面索引")]
    private int menu = 0;
    private bool behold;
    //[SerializeField]
    //private Transform revivePoint;
    //[SerializeField]
    //private Transform endline;
    //private float startPosition;
    //private float totalLen;

    private void Start()
    {
        events = GameEvents.instance;
        gravity = Physics2D.gravity;
        //startPosition = revivePoint.position.x;
        //totalLen = endline.position.x - startPosition;
        RegisterEvents();
        AddDebugEvents();
        StartGame();
    }

    //public int Progress
    //{
    //    get
    //    {
    //        return Mathf.FloorToInt((revivePoint.position.x - startPosition) / totalLen);
    //    }
    //}

    public void Restart()
    {
        _ = events.StartGame(beforeStartDelay, startDelay, endDelay);
    }

    public void Resume()
    {
        events.ResumeGame();
    }

    public void LoadMenu()
    {
        events.EndGame();
        _ = LoadScene(menu, endDelay);
    }

    public void Pause()
    {
        events.PauseGame();
    }

    private void RegisterEvents()
    {
        events.GameFailed += Restart;
        events.GamePause += PauseGravity;
        events.GameResume += ResumeGravity;
        events.GameAwake += ResumeGravity;
    }

    private void AddDebugEvents()
    {
        events.GameBeforeAwake += () => Debug.Log("game before awake");
        events.GameAwake += () => Debug.Log("game awake");
        events.GameStart += () => Debug.Log("game start");
        events.GameFailed += () => Debug.Log("game failed");
        events.GameWin += () => Debug.Log("game win");
        events.GameEnd += () => Debug.Log("game end");
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

    private void StartGame()
    {
        _ = events.StartGame(beforeStartDelay, startDelay, 10);
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
        if (behold) return;
        behold = true;
        await Task.Delay(delay);
        events.ClearEvents();
        events.ClearState();
        Physics2D.gravity = gravity;
        Debug.Log($"load scene {index}");
        SceneManager.LoadSceneAsync(index);
        behold = false;
    }

    private void OnApplicationPause(bool pause)
    {
        events?.PauseGame();
    }
}

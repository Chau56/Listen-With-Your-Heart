///<summary>
///作者：周权
///创建日期：2021-7-13
///最新修改日期：2021-7-17
///</summary>


using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GameLogicBehavior))]
public class InputProcessor : MonoBehaviour
{
    private GameEvents events;
    private float halfScreen;
    private Pointer currentPointer;
    private Touchscreen currentScreen;
    private GameLogicBehavior behavior;
    private float startPosition;

    private void Start()
    {
        events = GameEvents.instance;
        currentPointer = Pointer.current;
        currentScreen = Touchscreen.current;
        halfScreen = (float)Screen.height / 2;
        behavior = GetComponent<GameLogicBehavior>();
        Debug.Log($"halfscreen {halfScreen}");
    }

    private void OnJump1Started()
    {
        events.StartJump1();
    }

    private void OnJump1Finished()
    {
        events.FinishJump1();
    }

    private void OnJump2Started()
    {
        events.StartJump2();
    }

    private void OnJump2Finished()
    {
        events.FinishJump2();
    }

    private void OnPause()
    {
        if (!events.PauseGame())
        {
            events.ResumeGame();
        }
    }

    private void OnEndGame()
    {
        events.EndGame();
    }

    private void OnRestartGame()
    {
        behavior.Restart();
    }

}

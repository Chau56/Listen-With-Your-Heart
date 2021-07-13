using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProcessor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("场景加载完成后过多久调用GameStart。单位毫秒")]
    [Min(0)]
    private int startDelay = 1;
    [SerializeField]
    [Tooltip("GameFailed多久后重加载场景。单位毫秒")]
    [Min(0)]
    private int endDelay = 1;

    private GameEvents events;
    private float halfScreen;
    private Pointer currentPointer;
    private float startPosition;

    private void Start()
    {
        events = GameEvents.instance;
        currentPointer = Pointer.current;
        halfScreen = (float)Screen.height / 2;
        Debug.Log($"halfscreen {halfScreen}");
        RegisterEvents();
        BeforeStart();
    }

    private void RegisterEvents()
    {
        events.GameFailed += () => _ = events.RestartScene(endDelay);
    }

    private void BeforeStart()
    {
        events.Gravity = Physics2D.gravity;
        _ = events.WaitToStart(startDelay);
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

    private void SwichPointer(bool start, Action black, Action white)
    {
        switch (currentPointer)
        {
            case Touchscreen screen:
                foreach (var item in screen.touches)
                {
                    if (item.phase.ReadValue() != UnityEngine.InputSystem.TouchPhase.None)
                    {
                        startPosition = item.startPosition.y.ReadValue();
                        CheckPosition(black, white);
                    }
                }
                break;
            default:
                if (start)
                {
                    startPosition = currentPointer.position.y.ReadValue();
                    CheckPosition(black, white);
                }
                else
                {
                    CheckPosition(black, white);
                }
                break;
        }
    }

    private void CheckPosition(Action black, Action white)
    {
        Debug.Log($"jump start {startPosition}");
        if (startPosition < halfScreen)
        {
            black();
        }
        else
        {
            white();
        }
    }

    private void OnJumpStarted()
    {
        SwichPointer(true, events.StartJump1, events.StartJump2);
    }

    private void OnJumpFinished()
    {
        SwichPointer(false, events.FinishJump1, events.FinishJump2);
    }

    private void OnPause()
    {
        events.PauseGame();
    }

    private void OnApplicationPause(bool pause)
    {

    }

    private void OnApplicationQuit()
    {
        events.EndGame();
    }
}

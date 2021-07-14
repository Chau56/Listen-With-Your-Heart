using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProcessor : MonoBehaviour
{
    private GameEvents events;
    private float halfScreen;
    private Pointer currentPointer;

    public InputProcessor()
    {
        events = GameEvents.instance;
    }

    private void Start()
    {
        currentPointer = Pointer.current;
        halfScreen = (float)Screen.height / 2;
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

    private void SwichPointer(Func<bool> black, Func<bool> white)
    {
        float y;
        switch (currentPointer)
        {
            case Touchscreen screen:
                foreach (var item in screen.touches)
                {
                    if (item.phase.ReadValue() != UnityEngine.InputSystem.TouchPhase.None)
                    {
                        y = item.startPosition.y.ReadValue();
                        CheckPosition(y, black, white);
                    }
                }
                break;
            default:
                y = currentPointer.position.y.ReadValue();
                CheckPosition(y, black, white);
                break;
        }
    }

    private void CheckPosition(float y, Func<bool> black, Func<bool> white)
    {
        Debug.Log($"jump start {y}");
        if (y < halfScreen)
        {
            if (!black()) white();
        }
        else
        {
            if (!white()) black();
        }
    }

    private void OnJumpStarted()
    {
        SwichPointer(events.StartJump1, events.StartJump2);
    }

    private void OnJumpFinished()
    {
        SwichPointer(events.FinishJump1, events.FinishJump2);
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
        _ = events.StartGame(850, 950);
    }

    private void OnApplicationPause(bool pause)
    {
        events.PauseGame();
    }

}

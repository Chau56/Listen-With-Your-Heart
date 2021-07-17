using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

[RequireComponent(typeof(GameLogicBehavior))]
public class InputProcessor : MonoBehaviour
{
    private GameEvents events;
    private float halfScreen;
    private Mouse currentPointer;
    private Touchscreen currentScreen;
    private GameLogicBehavior behavior;
    private float startPosition;

    private void Start()
    {
        events = GameEvents.instance;
        currentPointer = Mouse.current;
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

    private void CheckPosition(float y, Func<bool> black, Func<bool> white)
    {
        Debug.Log($"jump start {y}");
        if (y < halfScreen)
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
        startPosition = currentPointer.position.y.ReadValue();
        CheckPosition(startPosition, events.StartJump1, events.StartJump2);
    }

    private void OnJumpFinished()
    {
        CheckPosition(startPosition, events.FinishJump1, events.FinishJump2);
    }

    private void TouchFilter(Func<bool> black, Func<bool> white)
    {
        foreach (var item in currentScreen.touches)
        {
            float y = item.position.y.ReadValue();
            if (item.phase.ReadValue() != TouchPhase.None)
            {
                CheckPosition(y, black, white);
            }
        }
    }

    private IEnumerator Tap()
    {
        TouchFilter(events.StartJump1, events.StartJump2);
        yield return new WaitForFixedUpdate();
        TouchFilter(events.FinishJump1, events.FinishJump2);
    }

    private void OnTap()
    {
        StartCoroutine(Tap());
    }

    private void OnJumpTouchStart()
    {
        TouchFilter(events.StartJump1, events.StartJump2);
    }

    private void OnJumpTouchFinish()
    {
        TouchFilter(events.FinishJump1, events.FinishJump2);
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

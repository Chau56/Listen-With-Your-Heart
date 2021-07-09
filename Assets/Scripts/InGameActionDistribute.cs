using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameActionDistribute
{
    public static readonly InGameActionDistribute instance = new InGameActionDistribute();
    private readonly CubeAction inputs;
    private CubeAction.CubeActions cube;
    private CubeAction.CheatActions cheat;
    /// <summary>
    /// 1是black 2是white。
    /// 或者全部反过来也可以。
    /// </summary>
    public event Action
        Impulse1, Impulse2, Pause1, Pause2, GamePause, GameResume, Jump1Start, Jump1Finished, Jump2Start, Jump2Finished;

    /// <summary>
    /// 默认注册器。
    /// </summary>
    private void DefaultRegister()
    {
        inputs.Game.Pause.started += _ =>
        {
            GamePause();
        };
        GamePause += () => Debug.Log("game paused");

        inputs.Game.Resume.started += _ =>
        {
            GameResume();
        };
        GameResume += () => Debug.Log("game resumed");

        cube.Jump1.performed += _ =>
        {
            Jump1Finished();
        };
        Jump1Finished += () => Debug.Log($"{nameof(Jump1Finished)}");

        cube.Jump1.started += _ =>
        {
            Jump1Start();
        };
        Jump1Start += () => Debug.Log($"{nameof(Jump1Start)}");

        cube.Jump2.performed += _ =>
        {
            Jump2Finished();
        };
        Jump2Finished += () => Debug.Log($"{nameof(Jump2Finished)}");

        cube.Jump2.started += _ =>
        {
            Jump2Start();
        };
        Jump2Start += () => Debug.Log($"{nameof(Jump2Start)}");

        cheat.Impulse1.started += _ =>
        {
            Impulse1();
        };
        Impulse1 += () => Debug.Log($"{nameof(Impulse1)}");

        cheat.Impulse2.started += _ =>
        {
            Impulse2();
        };
        Impulse2 += () => Debug.Log($"{nameof(Impulse2)}");

        cheat.Pause1.started += _ =>
        {
            Pause1();
        };
        Pause1 += () => Debug.Log($"{nameof(Pause1)}");

        cheat.Pause2.started += _ =>
        {
            Pause2();
        };
        Pause2 += () => Debug.Log($"{nameof(Pause2)}");

    }
    // Start is called before the first frame update
    private InGameActionDistribute()
    {
        inputs = new CubeAction();
        inputs.Enable();
        cube = inputs.Cube;
        cheat = inputs.Cheat;
        DefaultRegister();
    }
}

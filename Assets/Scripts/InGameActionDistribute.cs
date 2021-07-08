using System;
using UnityEngine;

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
        Jump1, Jump2, Impulse1, Impulse2, Pause1, Pause2, GamePause, GameResume;

    /// <summary>
    /// 默认注册器。
    /// </summary>
    private void DefaultRegister()
    {
        inputs.Game.Pause.performed += _ =>
        {
            GamePause();
        };
        GamePause += () => Debug.Log("game paused");

        inputs.Game.Resume.performed += _ =>
        {
            GameResume();
        };
        GameResume += () => Debug.Log("game resumed");

        cube.Jump1.performed += _ =>
        {
            Jump1();
        };
        Jump1 += () => Debug.Log($"{nameof(Jump1)}");

        cube.Jump2.performed += _ =>
        {
            Jump2();
        };
        Jump2 += () => Debug.Log($"{nameof(Jump2)}");

        cheat.Impulse1.performed += _ =>
        {
            Impulse1();
        };
        Impulse1 += () => Debug.Log($"{nameof(Impulse1)}");

        cheat.Impulse2.performed += _ =>
        {
            Impulse2();
        };
        Impulse2 += () => Debug.Log($"{nameof(Impulse2)}");

        cheat.Pause1.performed += _ =>
        {
            Pause1();
        };
        Pause1 += () => Debug.Log($"{nameof(Pause1)}");

        cheat.Pause2.performed += _ =>
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

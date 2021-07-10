using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace GameHardware
{
    public class InGameActionDistribute
    {
        public static readonly InGameActionDistribute instance = new InGameActionDistribute();
        private readonly CubeAction inputs;
        private CubeAction.CubeActions cube;
        private float screenHalfHeight;
        /// <summary>
        /// 1是black 2是white。
        /// 或者全部反过来也可以。
        /// </summary>
        public event Action
            Pause, Resume, Jump1Start, Jump1Finished, Jump2Start, Jump2Finished;

        /// <summary>
        /// 默认注册器。
        /// </summary>
        private void DefaultRegister()
        {
            inputs.Game.Pause.started += _ =>
            {
                Pause();
            };
            Pause += () => Debug.Log("hardware paused");

            inputs.Game.Resume.started += _ =>
            {
                Resume();
            };
            Resume += () => Debug.Log("hardware resumed");

            cube.Jump1.performed += context =>
            {
                JumpFilter(context.control, Jump1Finished, PlayerEnum.Black);
            };
            Jump1Finished += () => Debug.Log($"{nameof(Jump1Finished)}");

            cube.Jump1.started += context =>
            {
                JumpFilter(context.control, Jump1Start, PlayerEnum.Black);
            };
            Jump1Start += () => Debug.Log($"{nameof(Jump1Start)}");

            cube.Jump2.performed += context =>
            {
                JumpFilter(context.control, Jump2Finished, PlayerEnum.White);
            };
            Jump2Finished += () => Debug.Log($"{nameof(Jump2Finished)}");

            cube.Jump2.started += context =>
            {
                JumpFilter(context.control, Jump2Start, PlayerEnum.White);
            };
            Jump2Start += () => Debug.Log($"{nameof(Jump2Start)}");

            cube.Jump.performed += context =>
            {
                JumpFilter(context.control, Jump1Finished, PlayerEnum.Black);
            };

            cube.Jump.started += context =>
            {
                JumpFilter(context.control, Jump1Start, PlayerEnum.Black);
            };

            cube.Jump.performed += context =>
            {
                JumpFilter(context.control, Jump2Finished, PlayerEnum.White);
            };

            cube.Jump.started += context =>
            {
                JumpFilter(context.control, Jump2Start, PlayerEnum.White);
            };

        }
        private void JumpFilter(InputControl control, Action action, PlayerEnum player)
        {
            Debug.Log($"jump filter {control}");
            switch (control.device)
            {
                case Keyboard _:
                    action();
                    break;
                case Touchscreen screen:
                    foreach (var item in screen.touches)
                    {
                        var phase = item.phase.ReadValue();
                        if (phase != TouchPhase.None) TouchCheck(item.position, action, player);
                    }
                    break;
                case Mouse mouse:
                    TouchCheck(mouse.position, action, player);
                    break;
            }
        }

        private void TouchCheck(Vector2Control position, Action action, PlayerEnum player)
        {
            float y = position.y.ReadValue();
            Debug.Log($"screen hit y {y}");
            if (player == PlayerEnum.White && y > screenHalfHeight || player == PlayerEnum.Black && y < screenHalfHeight)
            {
                action();
                return;
            }
        }
        private void RegisterScreen()
        {
            screenHalfHeight = (float)Screen.height / 2;
            Debug.Log($"half screen {screenHalfHeight}");
        }
        // Start is called before the first frame update
        private InGameActionDistribute()
        {
            inputs = new CubeAction();
            inputs.Enable();
            cube = inputs.Cube;
            DefaultRegister();
            RegisterScreen();
        }
    }
}
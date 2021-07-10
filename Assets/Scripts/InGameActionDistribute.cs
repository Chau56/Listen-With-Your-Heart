using System;
using UnityEngine;
using UnityEngine.InputSystem;
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

            cube.JumpStart.performed += context =>
            {
                Debug.Log(context.control);
                Jump(context.control.device, Jump1Start, Jump2Start);
            };

            cube.JumpStop.performed += context =>
            {
                Debug.Log(context.control);
                Jump(context.control.device, Jump1Finished, Jump2Finished);
            };
        }

        private void Jump(InputDevice device, Action player1, Action player2)
        {
            switch (device)
            {
                case Mouse mouse:
                    CheckPosition(mouse.position.y.ReadValue(), player1, player2);
                    break;
                case Touchscreen screen:
                    foreach (var item in screen.touches)
                    {
                        if (item.phase.ReadValue() != TouchPhase.None) CheckPosition(item.position.y.ReadValue(), player1, player2);
                    }
                    break;
            }
        }

        private void CheckPosition(float position, Action player1, Action player2)
        {
            if (position < screenHalfHeight)
            {
                player1();
            }
            else
            {
                player2();
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
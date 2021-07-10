// GENERATED AUTOMATICALLY FROM 'Assets/Actions/CubeAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CubeAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CubeAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CubeAction"",
    ""maps"": [
        {
            ""name"": ""Cube"",
            ""id"": ""f42b9f81-49b5-40e9-aa45-85f9d87ac984"",
            ""actions"": [
                {
                    ""name"": ""Jump1"",
                    ""type"": ""Button"",
                    ""id"": ""de9dc7d7-fa42-4be2-a409-e75a0a15cdb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump2"",
                    ""type"": ""Button"",
                    ""id"": ""d3b4a11c-16a6-4d01-b172-0a9afe7490e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aee29416-93b9-4514-bc20-7ce9e81c474b"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877a9f1d-dbfc-48d6-b588-8723de2e1384"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7ffb7db-5be8-4d0f-bd73-bd03da149e7a"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c24e096a-2e21-4275-bc45-a933b00d568d"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""c1be2b32-0d33-48a6-a127-726524f9bbd7"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a2796d44-5601-4249-9ece-72bebd59a2ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""75acbacc-ed8f-484b-9145-dfab3dc2ce38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8046819-5159-429c-ab76-ef6b0a7445d7"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""515a8339-6e1d-493f-ad2b-c5152a6127a9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cube
        m_Cube = asset.FindActionMap("Cube", throwIfNotFound: true);
        m_Cube_Jump1 = m_Cube.FindAction("Jump1", throwIfNotFound: true);
        m_Cube_Jump2 = m_Cube.FindAction("Jump2", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Pause = m_Game.FindAction("Pause", throwIfNotFound: true);
        m_Game_Resume = m_Game.FindAction("Resume", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Cube
    private readonly InputActionMap m_Cube;
    private ICubeActions m_CubeActionsCallbackInterface;
    private readonly InputAction m_Cube_Jump1;
    private readonly InputAction m_Cube_Jump2;
    public struct CubeActions
    {
        private @CubeAction m_Wrapper;
        public CubeActions(@CubeAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump1 => m_Wrapper.m_Cube_Jump1;
        public InputAction @Jump2 => m_Wrapper.m_Cube_Jump2;
        public InputActionMap Get() { return m_Wrapper.m_Cube; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CubeActions set) { return set.Get(); }
        public void SetCallbacks(ICubeActions instance)
        {
            if (m_Wrapper.m_CubeActionsCallbackInterface != null)
            {
                @Jump1.started -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump1;
                @Jump1.performed -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump1;
                @Jump1.canceled -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump1;
                @Jump2.started -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_CubeActionsCallbackInterface.OnJump2;
            }
            m_Wrapper.m_CubeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump1.started += instance.OnJump1;
                @Jump1.performed += instance.OnJump1;
                @Jump1.canceled += instance.OnJump1;
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
            }
        }
    }
    public CubeActions @Cube => new CubeActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Pause;
    private readonly InputAction m_Game_Resume;
    public struct GameActions
    {
        private @CubeAction m_Wrapper;
        public GameActions(@CubeAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Game_Pause;
        public InputAction @Resume => m_Wrapper.m_Game_Resume;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Resume.started -= m_Wrapper.m_GameActionsCallbackInterface.OnResume;
                @Resume.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnResume;
                @Resume.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnResume;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Resume.started += instance.OnResume;
                @Resume.performed += instance.OnResume;
                @Resume.canceled += instance.OnResume;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface ICubeActions
    {
        void OnJump1(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnResume(InputAction.CallbackContext context);
    }
}

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
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877a9f1d-dbfc-48d6-b588-8723de2e1384"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7ffb7db-5be8-4d0f-bd73-bd03da149e7a"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
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
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cheat"",
            ""id"": ""45b7f2a3-8d19-49fc-888f-d5e5fcdf30f7"",
            ""actions"": [
                {
                    ""name"": ""Pause1"",
                    ""type"": ""Button"",
                    ""id"": ""84981d35-c07b-45bc-b5bf-3b87c3ae152c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause2"",
                    ""type"": ""Button"",
                    ""id"": ""72e492a0-075a-4bef-b908-3ee075d1250e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Impulse1"",
                    ""type"": ""Button"",
                    ""id"": ""185ac96f-e926-46db-ae79-5184c9336f6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Impulse2"",
                    ""type"": ""Button"",
                    ""id"": ""9368958b-7620-45e6-9827-cf0f2944b600"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11424a8e-85ca-4895-adb0-b0bf5f926cb0"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2538f1b-fd46-4704-a3e0-5f9a07a25228"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664c3c01-2c9f-41bf-9eb3-f401baf38066"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Impulse1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b51a026d-a220-432d-a27e-6959cc25e7eb"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Impulse2"",
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
        // Cheat
        m_Cheat = asset.FindActionMap("Cheat", throwIfNotFound: true);
        m_Cheat_Pause1 = m_Cheat.FindAction("Pause1", throwIfNotFound: true);
        m_Cheat_Pause2 = m_Cheat.FindAction("Pause2", throwIfNotFound: true);
        m_Cheat_Impulse1 = m_Cheat.FindAction("Impulse1", throwIfNotFound: true);
        m_Cheat_Impulse2 = m_Cheat.FindAction("Impulse2", throwIfNotFound: true);
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

    // Cheat
    private readonly InputActionMap m_Cheat;
    private ICheatActions m_CheatActionsCallbackInterface;
    private readonly InputAction m_Cheat_Pause1;
    private readonly InputAction m_Cheat_Pause2;
    private readonly InputAction m_Cheat_Impulse1;
    private readonly InputAction m_Cheat_Impulse2;
    public struct CheatActions
    {
        private @CubeAction m_Wrapper;
        public CheatActions(@CubeAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause1 => m_Wrapper.m_Cheat_Pause1;
        public InputAction @Pause2 => m_Wrapper.m_Cheat_Pause2;
        public InputAction @Impulse1 => m_Wrapper.m_Cheat_Impulse1;
        public InputAction @Impulse2 => m_Wrapper.m_Cheat_Impulse2;
        public InputActionMap Get() { return m_Wrapper.m_Cheat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatActions set) { return set.Get(); }
        public void SetCallbacks(ICheatActions instance)
        {
            if (m_Wrapper.m_CheatActionsCallbackInterface != null)
            {
                @Pause1.started -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause1;
                @Pause1.performed -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause1;
                @Pause1.canceled -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause1;
                @Pause2.started -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause2;
                @Pause2.performed -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause2;
                @Pause2.canceled -= m_Wrapper.m_CheatActionsCallbackInterface.OnPause2;
                @Impulse1.started -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse1;
                @Impulse1.performed -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse1;
                @Impulse1.canceled -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse1;
                @Impulse2.started -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse2;
                @Impulse2.performed -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse2;
                @Impulse2.canceled -= m_Wrapper.m_CheatActionsCallbackInterface.OnImpulse2;
            }
            m_Wrapper.m_CheatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause1.started += instance.OnPause1;
                @Pause1.performed += instance.OnPause1;
                @Pause1.canceled += instance.OnPause1;
                @Pause2.started += instance.OnPause2;
                @Pause2.performed += instance.OnPause2;
                @Pause2.canceled += instance.OnPause2;
                @Impulse1.started += instance.OnImpulse1;
                @Impulse1.performed += instance.OnImpulse1;
                @Impulse1.canceled += instance.OnImpulse1;
                @Impulse2.started += instance.OnImpulse2;
                @Impulse2.performed += instance.OnImpulse2;
                @Impulse2.canceled += instance.OnImpulse2;
            }
        }
    }
    public CheatActions @Cheat => new CheatActions(this);
    public interface ICubeActions
    {
        void OnJump1(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
    }
    public interface ICheatActions
    {
        void OnPause1(InputAction.CallbackContext context);
        void OnPause2(InputAction.CallbackContext context);
        void OnImpulse1(InputAction.CallbackContext context);
        void OnImpulse2(InputAction.CallbackContext context);
    }
}

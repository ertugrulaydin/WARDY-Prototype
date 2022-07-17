// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Concretes/Inputs/DefaultAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace WARDY.Inputs
{
    public class @DefaultAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DefaultAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultAction"",
    ""maps"": [
        {
            ""name"": ""PlayerMove"",
            ""id"": ""8e413648-ec3c-492a-bb17-c19a9634f64a"",
            ""actions"": [
                {
                    ""name"": ""UpDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""806f4903-efc5-4aae-95d8-fb8ce92ccb4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba314188-4cf2-4e13-8a7c-72dd538fffd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b783ec76-3bb9-41f1-b0e9-ad3430bdf719"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9c9f4c5b-f1a7-432e-84b1-3370092539a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3b5ba921-3c68-497f-8f23-b40ec48a2398"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d04c8bb8-8e21-48bf-ba67-831f2e92ac43"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMove
            m_PlayerMove = asset.FindActionMap("PlayerMove", throwIfNotFound: true);
            m_PlayerMove_UpDown = m_PlayerMove.FindAction("UpDown", throwIfNotFound: true);
            m_PlayerMove_Fire = m_PlayerMove.FindAction("Fire", throwIfNotFound: true);
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

        // PlayerMove
        private readonly InputActionMap m_PlayerMove;
        private IPlayerMoveActions m_PlayerMoveActionsCallbackInterface;
        private readonly InputAction m_PlayerMove_UpDown;
        private readonly InputAction m_PlayerMove_Fire;
        public struct PlayerMoveActions
        {
            private @DefaultAction m_Wrapper;
            public PlayerMoveActions(@DefaultAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @UpDown => m_Wrapper.m_PlayerMove_UpDown;
            public InputAction @Fire => m_Wrapper.m_PlayerMove_Fire;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMove; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMoveActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMoveActions instance)
            {
                if (m_Wrapper.m_PlayerMoveActionsCallbackInterface != null)
                {
                    @UpDown.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnUpDown;
                    @UpDown.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnUpDown;
                    @UpDown.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnUpDown;
                    @Fire.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_PlayerMoveActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @UpDown.started += instance.OnUpDown;
                    @UpDown.performed += instance.OnUpDown;
                    @UpDown.canceled += instance.OnUpDown;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public PlayerMoveActions @PlayerMove => new PlayerMoveActions(this);
        public interface IPlayerMoveActions
        {
            void OnUpDown(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
    }
}

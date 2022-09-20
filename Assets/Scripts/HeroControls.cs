// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/HeroControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @HeroControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HeroControls"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""62ff5649-c1b4-4eca-a22f-849301b2e0aa"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""37847769-abe0-431a-b53e-0cf072bf4896"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98543e44-e882-43b1-8f34-2b0c4eed133a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_Move = m_Hero.FindAction("Move", throwIfNotFound: true);
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

    // Hero
    private readonly InputActionMap m_Hero;
    private IHeroActions m_HeroActionsCallbackInterface;
    private readonly InputAction m_Hero_Move;
    public struct HeroActions
    {
        private @HeroControls m_Wrapper;
        public HeroActions(@HeroControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Hero_Move;
        public InputActionMap Get() { return m_Wrapper.m_Hero; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeroActions set) { return set.Get(); }
        public void SetCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}

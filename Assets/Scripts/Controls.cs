//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.13.1
//     from Assets/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

/// <summary>
/// Provides programmatic access to <see cref="InputActionAsset" />, <see cref="InputActionMap" />, <see cref="InputAction" /> and <see cref="InputControlScheme" /> instances defined in asset "Assets/Controls.inputactions".
/// </summary>
/// <remarks>
/// This class is source generated and any manual edits will be discarded if the associated asset is reimported or modified.
/// </remarks>
/// <example>
/// <code>
/// using namespace UnityEngine;
/// using UnityEngine.InputSystem;
///
/// // Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
/// public class Example : MonoBehaviour, MyActions.IPlayerActions
/// {
///     private MyActions_Actions m_Actions;                  // Source code representation of asset.
///     private MyActions_Actions.PlayerActions m_Player;     // Source code representation of action map.
///
///     void Awake()
///     {
///         m_Actions = new MyActions_Actions();              // Create asset object.
///         m_Player = m_Actions.Player;                      // Extract action map object.
///         m_Player.AddCallbacks(this);                      // Register callback interface IPlayerActions.
///     }
///
///     void OnDestroy()
///     {
///         m_Actions.Dispose();                              // Destroy asset object.
///     }
///
///     void OnEnable()
///     {
///         m_Player.Enable();                                // Enable all actions within map.
///     }
///
///     void OnDisable()
///     {
///         m_Player.Disable();                               // Disable all actions within map.
///     }
///
///     #region Interface implementation of MyActions.IPlayerActions
///
///     // Invoked when "Move" action is either started, performed or canceled.
///     public void OnMove(InputAction.CallbackContext context)
///     {
///         Debug.Log($"OnMove: {context.ReadValue&lt;Vector2&gt;()}");
///     }
///
///     // Invoked when "Attack" action is either started, performed or canceled.
///     public void OnAttack(InputAction.CallbackContext context)
///     {
///         Debug.Log($"OnAttack: {context.ReadValue&lt;float&gt;()}");
///     }
///
///     #endregion
/// }
/// </code>
/// </example>
public partial class @Controls: IInputActionCollection2, IDisposable
{
    /// <summary>
    /// Provides access to the underlying asset instance.
    /// </summary>
    public InputActionAsset asset { get; }

    /// <summary>
    /// Constructs a new instance.
    /// </summary>
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Default Gameplay"",
            ""id"": ""cd36f807-016f-4d7e-9bcc-8e7a9d2b7eb5"",
            ""actions"": [
                {
                    ""name"": ""ActivateMouseMovement"",
                    ""type"": ""Button"",
                    ""id"": ""bac1e2fb-7be6-4f4a-b480-3ff7c04339e3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom Camera"",
                    ""type"": ""Value"",
                    ""id"": ""39fc58ff-0a81-42bf-a614-fbd7c3b211ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Place Machine"",
                    ""type"": ""Button"",
                    ""id"": ""420f6cfd-b996-49bc-b199-17629b0c1a5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Next Machine"",
                    ""type"": ""Button"",
                    ""id"": ""09d13509-4135-4337-b18b-7cac7a6e99c7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Previous Machine"",
                    ""type"": ""Button"",
                    ""id"": ""66bf41c2-f701-405e-837d-15acfb376069"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a6a23cc-aec3-42e0-86bb-bca711e970c5"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20acc8c6-b4e1-4305-9eef-42d41bf81638"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place Machine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ec301d1-2d60-4370-b5a1-e3ca6fd07e71"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next Machine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8834387-d2ec-4833-9095-309de1035b9a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Machine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120c8f07-fd0f-41c0-8632-b2fe3ba3702b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateMouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default Gameplay
        m_DefaultGameplay = asset.FindActionMap("Default Gameplay", throwIfNotFound: true);
        m_DefaultGameplay_ActivateMouseMovement = m_DefaultGameplay.FindAction("ActivateMouseMovement", throwIfNotFound: true);
        m_DefaultGameplay_ZoomCamera = m_DefaultGameplay.FindAction("Zoom Camera", throwIfNotFound: true);
        m_DefaultGameplay_PlaceMachine = m_DefaultGameplay.FindAction("Place Machine", throwIfNotFound: true);
        m_DefaultGameplay_NextMachine = m_DefaultGameplay.FindAction("Next Machine", throwIfNotFound: true);
        m_DefaultGameplay_PreviousMachine = m_DefaultGameplay.FindAction("Previous Machine", throwIfNotFound: true);
    }

    ~@Controls()
    {
        UnityEngine.Debug.Assert(!m_DefaultGameplay.enabled, "This will cause a leak and performance issues, Controls.DefaultGameplay.Disable() has not been called.");
    }

    /// <summary>
    /// Destroys this asset and all associated <see cref="InputAction"/> instances.
    /// </summary>
    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindingMask" />
    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.devices" />
    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.controlSchemes" />
    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Contains(InputAction)" />
    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.GetEnumerator()" />
    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    /// <inheritdoc cref="IEnumerable.GetEnumerator()" />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Enable()" />
    public void Enable()
    {
        asset.Enable();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Disable()" />
    public void Disable()
    {
        asset.Disable();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindings" />
    public IEnumerable<InputBinding> bindings => asset.bindings;

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindAction(string, bool)" />
    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindBinding(InputBinding, out InputAction)" />
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Default Gameplay
    private readonly InputActionMap m_DefaultGameplay;
    private List<IDefaultGameplayActions> m_DefaultGameplayActionsCallbackInterfaces = new List<IDefaultGameplayActions>();
    private readonly InputAction m_DefaultGameplay_ActivateMouseMovement;
    private readonly InputAction m_DefaultGameplay_ZoomCamera;
    private readonly InputAction m_DefaultGameplay_PlaceMachine;
    private readonly InputAction m_DefaultGameplay_NextMachine;
    private readonly InputAction m_DefaultGameplay_PreviousMachine;
    /// <summary>
    /// Provides access to input actions defined in input action map "Default Gameplay".
    /// </summary>
    public struct DefaultGameplayActions
    {
        private @Controls m_Wrapper;

        /// <summary>
        /// Construct a new instance of the input action map wrapper class.
        /// </summary>
        public DefaultGameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        /// <summary>
        /// Provides access to the underlying input action "DefaultGameplay/ActivateMouseMovement".
        /// </summary>
        public InputAction @ActivateMouseMovement => m_Wrapper.m_DefaultGameplay_ActivateMouseMovement;
        /// <summary>
        /// Provides access to the underlying input action "DefaultGameplay/ZoomCamera".
        /// </summary>
        public InputAction @ZoomCamera => m_Wrapper.m_DefaultGameplay_ZoomCamera;
        /// <summary>
        /// Provides access to the underlying input action "DefaultGameplay/PlaceMachine".
        /// </summary>
        public InputAction @PlaceMachine => m_Wrapper.m_DefaultGameplay_PlaceMachine;
        /// <summary>
        /// Provides access to the underlying input action "DefaultGameplay/NextMachine".
        /// </summary>
        public InputAction @NextMachine => m_Wrapper.m_DefaultGameplay_NextMachine;
        /// <summary>
        /// Provides access to the underlying input action "DefaultGameplay/PreviousMachine".
        /// </summary>
        public InputAction @PreviousMachine => m_Wrapper.m_DefaultGameplay_PreviousMachine;
        /// <summary>
        /// Provides access to the underlying input action map instance.
        /// </summary>
        public InputActionMap Get() { return m_Wrapper.m_DefaultGameplay; }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Enable()" />
        public void Enable() { Get().Enable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Disable()" />
        public void Disable() { Get().Disable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.enabled" />
        public bool enabled => Get().enabled;
        /// <summary>
        /// Implicitly converts an <see ref="DefaultGameplayActions" /> to an <see ref="InputActionMap" /> instance.
        /// </summary>
        public static implicit operator InputActionMap(DefaultGameplayActions set) { return set.Get(); }
        /// <summary>
        /// Adds <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <param name="instance">Callback instance.</param>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c> or <paramref name="instance"/> have already been added this method does nothing.
        /// </remarks>
        /// <seealso cref="DefaultGameplayActions" />
        public void AddCallbacks(IDefaultGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_DefaultGameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DefaultGameplayActionsCallbackInterfaces.Add(instance);
            @ActivateMouseMovement.started += instance.OnActivateMouseMovement;
            @ActivateMouseMovement.performed += instance.OnActivateMouseMovement;
            @ActivateMouseMovement.canceled += instance.OnActivateMouseMovement;
            @ZoomCamera.started += instance.OnZoomCamera;
            @ZoomCamera.performed += instance.OnZoomCamera;
            @ZoomCamera.canceled += instance.OnZoomCamera;
            @PlaceMachine.started += instance.OnPlaceMachine;
            @PlaceMachine.performed += instance.OnPlaceMachine;
            @PlaceMachine.canceled += instance.OnPlaceMachine;
            @NextMachine.started += instance.OnNextMachine;
            @NextMachine.performed += instance.OnNextMachine;
            @NextMachine.canceled += instance.OnNextMachine;
            @PreviousMachine.started += instance.OnPreviousMachine;
            @PreviousMachine.performed += instance.OnPreviousMachine;
            @PreviousMachine.canceled += instance.OnPreviousMachine;
        }

        /// <summary>
        /// Removes <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <remarks>
        /// Calling this method when <paramref name="instance" /> have not previously been registered has no side-effects.
        /// </remarks>
        /// <seealso cref="DefaultGameplayActions" />
        private void UnregisterCallbacks(IDefaultGameplayActions instance)
        {
            @ActivateMouseMovement.started -= instance.OnActivateMouseMovement;
            @ActivateMouseMovement.performed -= instance.OnActivateMouseMovement;
            @ActivateMouseMovement.canceled -= instance.OnActivateMouseMovement;
            @ZoomCamera.started -= instance.OnZoomCamera;
            @ZoomCamera.performed -= instance.OnZoomCamera;
            @ZoomCamera.canceled -= instance.OnZoomCamera;
            @PlaceMachine.started -= instance.OnPlaceMachine;
            @PlaceMachine.performed -= instance.OnPlaceMachine;
            @PlaceMachine.canceled -= instance.OnPlaceMachine;
            @NextMachine.started -= instance.OnNextMachine;
            @NextMachine.performed -= instance.OnNextMachine;
            @NextMachine.canceled -= instance.OnNextMachine;
            @PreviousMachine.started -= instance.OnPreviousMachine;
            @PreviousMachine.performed -= instance.OnPreviousMachine;
            @PreviousMachine.canceled -= instance.OnPreviousMachine;
        }

        /// <summary>
        /// Unregisters <param cref="instance" /> and unregisters all input action callbacks via <see cref="DefaultGameplayActions.UnregisterCallbacks(IDefaultGameplayActions)" />.
        /// </summary>
        /// <seealso cref="DefaultGameplayActions.UnregisterCallbacks(IDefaultGameplayActions)" />
        public void RemoveCallbacks(IDefaultGameplayActions instance)
        {
            if (m_Wrapper.m_DefaultGameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        /// <summary>
        /// Replaces all existing callback instances and previously registered input action callbacks associated with them with callbacks provided via <param cref="instance" />.
        /// </summary>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c>, calling this method will only unregister all existing callbacks but not register any new callbacks.
        /// </remarks>
        /// <seealso cref="DefaultGameplayActions.AddCallbacks(IDefaultGameplayActions)" />
        /// <seealso cref="DefaultGameplayActions.RemoveCallbacks(IDefaultGameplayActions)" />
        /// <seealso cref="DefaultGameplayActions.UnregisterCallbacks(IDefaultGameplayActions)" />
        public void SetCallbacks(IDefaultGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_DefaultGameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DefaultGameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    /// <summary>
    /// Provides a new <see cref="DefaultGameplayActions" /> instance referencing this action map.
    /// </summary>
    public DefaultGameplayActions @DefaultGameplay => new DefaultGameplayActions(this);
    /// <summary>
    /// Interface to implement callback methods for all input action callbacks associated with input actions defined by "Default Gameplay" which allows adding and removing callbacks.
    /// </summary>
    /// <seealso cref="DefaultGameplayActions.AddCallbacks(IDefaultGameplayActions)" />
    /// <seealso cref="DefaultGameplayActions.RemoveCallbacks(IDefaultGameplayActions)" />
    public interface IDefaultGameplayActions
    {
        /// <summary>
        /// Method invoked when associated input action "ActivateMouseMovement" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnActivateMouseMovement(InputAction.CallbackContext context);
        /// <summary>
        /// Method invoked when associated input action "Zoom Camera" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnZoomCamera(InputAction.CallbackContext context);
        /// <summary>
        /// Method invoked when associated input action "Place Machine" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnPlaceMachine(InputAction.CallbackContext context);
        /// <summary>
        /// Method invoked when associated input action "Next Machine" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnNextMachine(InputAction.CallbackContext context);
        /// <summary>
        /// Method invoked when associated input action "Previous Machine" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnPreviousMachine(InputAction.CallbackContext context);
    }
}

using System;
using UnityEngine;

namespace KXL.Input
{
    using Interfaces;
    using Input = UnityEngine.Input;

    public static class PlayerInputGroup
    {
        public enum PlayerInputName
        {
            Up,
            Down,
            Left,
            Right,
            Jump,
            Interact,
            Menu,
        }

        public struct PlayerInputState
        {
            public bool up;
            public bool down;
            public bool left;
            public bool right;
            public bool jump;
            public bool interact;
            public bool menu;
        }

        static PlayerInputState currentState;
        static PlayerInputState prevState;

        public static PlayerInputState CurrentState {
            get { return currentState; }
        }
        public static PlayerInputState PrevState {
            get { return prevState; }
        }

        public static void OnUpdate() {
            prevState = currentState;

            UpdateUpInput();
            UpdateDownInput();
            UpdateLeftInput();
            UpdateRightInput();
            UpdateJumpInput();
            UpdateInteractInput();
            UpdateMenuInput();
        }

        #region Up
        public static event Action OnUpInputDown;
        public static event Action OnUpInputUp;
        static void UpdateUpInput() {
            currentState.up = Input.GetKey(KeyCode.UpArrow);
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                OnUpInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow)) {
                OnUpInputUp?.Invoke();
            }
        }
        public static void RegisterUpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterUpConsumer;
            consumer.OnDestroyEvent += UnregisterUpConsumer;

            IUpInputConsumer UpConsumer = consumer as IUpInputConsumer;
            OnUpInputDown += UpConsumer.HandleUpInputDown;
            OnUpInputUp += UpConsumer.HandleUpInputUp;
        }
        public static void UnregisterUpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterUpConsumer;
            consumer.OnDestroyEvent -= UnregisterUpConsumer;

            IUpInputConsumer UpConsumer = consumer as IUpInputConsumer;
            OnUpInputDown -= UpConsumer.HandleUpInputDown;
            OnUpInputUp -= UpConsumer.HandleUpInputUp;
        }
        public interface IUpInputConsumer
        {
            public void HandleUpInputDown();
            public void HandleUpInputUp();
        }
        #endregion

        #region Down
        public static event Action OnDownInputDown;
        public static event Action OnDownInputUp;
        static void UpdateDownInput() {
            currentState.down = Input.GetKey(KeyCode.DownArrow);
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                OnDownInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                OnDownInputUp?.Invoke();
            }
        }
        public static void RegisterDownConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterDownConsumer;
            consumer.OnDestroyEvent += UnregisterDownConsumer;

            IDownInputConsumer DownConsumer = consumer as IDownInputConsumer;
            OnDownInputDown += DownConsumer.HandleDownInputDown;
            OnDownInputUp += DownConsumer.HandleDownInputUp;
        }
        public static void UnregisterDownConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterDownConsumer;
            consumer.OnDestroyEvent -= UnregisterDownConsumer;

            IDownInputConsumer DownConsumer = consumer as IDownInputConsumer;
            OnDownInputDown -= DownConsumer.HandleDownInputDown;
            OnDownInputUp -= DownConsumer.HandleDownInputUp;
        }
        public interface IDownInputConsumer
        {
            public void HandleDownInputDown();
            public void HandleDownInputUp();
        }
        #endregion

        #region Left
        public static event Action OnLeftInputDown;
        public static event Action OnLeftInputUp;
        static void UpdateLeftInput() {
            currentState.left = Input.GetKey(KeyCode.LeftArrow);
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                OnLeftInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                OnLeftInputUp?.Invoke();
            }
        }
        public static void RegisterLeftConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterLeftConsumer;
            consumer.OnDestroyEvent += UnregisterLeftConsumer;

            ILeftInputConsumer LeftConsumer = consumer as ILeftInputConsumer;
            OnLeftInputDown += LeftConsumer.HandleLeftInputDown;
            OnLeftInputUp += LeftConsumer.HandleLeftInputUp;
        }
        public static void UnregisterLeftConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterLeftConsumer;
            consumer.OnDestroyEvent -= UnregisterLeftConsumer;

            ILeftInputConsumer LeftConsumer = consumer as ILeftInputConsumer;
            OnLeftInputDown -= LeftConsumer.HandleLeftInputDown;
            OnLeftInputUp -= LeftConsumer.HandleLeftInputUp;
        }
        public interface ILeftInputConsumer
        {
            public void HandleLeftInputDown();
            public void HandleLeftInputUp();
        }
        #endregion

        #region Right
        public static event Action OnRightInputDown;
        public static event Action OnRightInputUp;
        static void UpdateRightInput() {
            currentState.right = Input.GetKey(KeyCode.RightArrow);
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                OnRightInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow)) {
                OnRightInputUp?.Invoke();
            }
        }
        public static void RegisterRightConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterRightConsumer;
            consumer.OnDestroyEvent += UnregisterRightConsumer;

            IRightInputConsumer RightConsumer = consumer as IRightInputConsumer;
            OnRightInputDown += RightConsumer.HandleRightInputDown;
            OnRightInputUp += RightConsumer.HandleRightInputUp;
        }
        public static void UnregisterRightConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterRightConsumer;
            consumer.OnDestroyEvent -= UnregisterRightConsumer;

            IRightInputConsumer RightConsumer = consumer as IRightInputConsumer;
            OnRightInputDown -= RightConsumer.HandleRightInputDown;
            OnRightInputUp -= RightConsumer.HandleRightInputUp;
        }
        public interface IRightInputConsumer
        {
            public void HandleRightInputDown();
            public void HandleRightInputUp();
        }
        #endregion

        #region Jump
        public static event Action OnJumpInputDown;
        public static event Action OnJumpInputUp;
        static void UpdateJumpInput() {
            currentState.jump = Input.GetKey(KeyCode.X);
            if (Input.GetKeyDown(KeyCode.X)) {
                OnJumpInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.X)) {
                OnJumpInputUp?.Invoke();
            }
        }
        public static void RegisterJumpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterJumpConsumer;
            consumer.OnDestroyEvent += UnregisterJumpConsumer;

            IJumpInputConsumer JumpConsumer = consumer as IJumpInputConsumer;
            OnJumpInputDown += JumpConsumer.HandleJumpInputDown;
            OnJumpInputUp += JumpConsumer.HandleJumpInputUp;
        }
        public static void UnregisterJumpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterJumpConsumer;
            consumer.OnDestroyEvent -= UnregisterJumpConsumer;

            IJumpInputConsumer JumpConsumer = consumer as IJumpInputConsumer;
            OnJumpInputDown -= JumpConsumer.HandleJumpInputDown;
            OnJumpInputUp -= JumpConsumer.HandleJumpInputUp;
        }
        public interface IJumpInputConsumer
        {
            public void HandleJumpInputDown();
            public void HandleJumpInputUp();
        }
        #endregion

        #region Interact
        public static event Action OnInteractInputDown;
        public static event Action OnInteractInputUp;
        static void UpdateInteractInput() {
            currentState.interact = Input.GetKey(KeyCode.Z);
            if (Input.GetKeyDown(KeyCode.Z)) {
                OnInteractInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Z)) {
                OnInteractInputUp?.Invoke();
            }
        }
        public static void RegisterInteractConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterInteractConsumer;
            consumer.OnDestroyEvent += UnregisterInteractConsumer;

            IInteractInputConsumer InteractConsumer = consumer as IInteractInputConsumer;
            OnInteractInputDown += InteractConsumer.HandleInteractInputDown;
            OnInteractInputUp += InteractConsumer.HandleInteractInputUp;
        }
        public static void UnregisterInteractConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterInteractConsumer;
            consumer.OnDestroyEvent -= UnregisterInteractConsumer;

            IInteractInputConsumer InteractConsumer = consumer as IInteractInputConsumer;
            OnInteractInputDown -= InteractConsumer.HandleInteractInputDown;
            OnInteractInputUp -= InteractConsumer.HandleInteractInputUp;
        }
        public interface IInteractInputConsumer
        {
            public void HandleInteractInputDown();
            public void HandleInteractInputUp();
        }
        #endregion

        #region Menu
        public static event Action OnMenuInputDown;
        public static event Action OnMenuInputUp;
        static void UpdateMenuInput() {
            currentState.menu = Input.GetKey(KeyCode.Tab);
            if (Input.GetKeyDown(KeyCode.Tab)) {
                OnMenuInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Tab)) {
                OnMenuInputUp?.Invoke();
            }
        }
        public static void RegisterMenuConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterMenuConsumer;
            consumer.OnDestroyEvent += UnregisterMenuConsumer;

            IMenuInputConsumer MenuConsumer = consumer as IMenuInputConsumer;
            OnMenuInputDown += MenuConsumer.HandleMenuInputDown;
            OnMenuInputUp += MenuConsumer.HandleMenuInputUp;
        }
        public static void UnregisterMenuConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterMenuConsumer;
            consumer.OnDestroyEvent -= UnregisterMenuConsumer;

            IMenuInputConsumer MenuConsumer = consumer as IMenuInputConsumer;
            OnMenuInputDown -= MenuConsumer.HandleMenuInputDown;
            OnMenuInputUp -= MenuConsumer.HandleMenuInputUp;
        }
        public interface IMenuInputConsumer
        {
            public void HandleMenuInputDown();
            public void HandleMenuInputUp();
        }
        #endregion
    }
}
using System;
using UnityEngine;

namespace KXL.Input
{
    using Interfaces;
    using Input = UnityEngine.Input;

    public static class MenuInputGroup
    {
        public enum MenuInputName
        {
            Up,
            Down,
            Left,
            Right,
            Cancel,
            Confirm,
        }

        public struct MenuInputState
        {
            public bool up;
            public bool down;
            public bool left;
            public bool right;
            public bool cancel;
            public bool confirm;
        }

        static MenuInputState currentState;
        static MenuInputState prevState;

        public static MenuInputState CurrentState {
            get { return currentState; }
        }
        public static MenuInputState PrevState {
            get { return prevState; }
        }
        public static void OnUpdate() {
            prevState = currentState;

            UpdateUpInput();
            UpdateDownInput();
            UpdateLeftInput();
            UpdateRightInput();
            UpdateCancelInput();
            UpdateConfirmInput();
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

        #region Cancel
        public static event Action OnCancelInputDown;
        public static event Action OnCancelInputUp;
        static void UpdateCancelInput() {
            currentState.cancel = Input.GetKey(KeyCode.X);
            if (Input.GetKeyDown(KeyCode.X)) {
                OnCancelInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.X)) {
                OnCancelInputUp?.Invoke();
            }
        }
        public static void RegisterCancelConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterCancelConsumer;
            consumer.OnDestroyEvent += UnregisterCancelConsumer;

            ICancelInputConsumer CancelConsumer = consumer as ICancelInputConsumer;
            OnCancelInputDown += CancelConsumer.HandleCancelInputDown;
            OnCancelInputUp += CancelConsumer.HandleCancelInputUp;
        }
        public static void UnregisterCancelConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterCancelConsumer;
            consumer.OnDestroyEvent -= UnregisterCancelConsumer;

            ICancelInputConsumer CancelConsumer = consumer as ICancelInputConsumer;
            OnCancelInputDown -= CancelConsumer.HandleCancelInputDown;
            OnCancelInputUp -= CancelConsumer.HandleCancelInputUp;
        }
        public interface ICancelInputConsumer
        {
            public void HandleCancelInputDown();
            public void HandleCancelInputUp();
        }
        #endregion

        #region Confirm
        public static event Action OnConfirmInputDown;
        public static event Action OnConfirmInputUp;
        static void UpdateConfirmInput() {
            currentState.confirm = Input.GetKey(KeyCode.Z);
            if (Input.GetKeyDown(KeyCode.Z)) {
                OnConfirmInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Z)) {
                OnConfirmInputUp?.Invoke();
            }
        }
        public static void RegisterConfirmConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterConfirmConsumer;
            consumer.OnDestroyEvent += UnregisterConfirmConsumer;

            IConfirmInputConsumer ConfirmConsumer = consumer as IConfirmInputConsumer;
            OnConfirmInputDown += ConfirmConsumer.HandleConfirmInputDown;
            OnConfirmInputUp += ConfirmConsumer.HandleConfirmInputUp;
        }
        public static void UnregisterConfirmConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterConfirmConsumer;
            consumer.OnDestroyEvent -= UnregisterConfirmConsumer;

            IConfirmInputConsumer ConfirmConsumer = consumer as IConfirmInputConsumer;
            OnConfirmInputDown -= ConfirmConsumer.HandleConfirmInputDown;
            OnConfirmInputUp -= ConfirmConsumer.HandleConfirmInputUp;
        }
        public interface IConfirmInputConsumer
        {
            public void HandleConfirmInputDown();
            public void HandleConfirmInputUp();
        }
        #endregion
    }
}
using System;
using UnityEngine;

namespace KXL.Input
{
    using KXL.Core.Interfaces;
    using Interfaces;
    using Input = UnityEngine.Input;

    public static class PlayerInputGroup
    {
        public struct PlayerInputState
        {
            public bool up;
            public bool down;
            public bool left;
            public bool right;
            public bool attack1;
            public bool attack2;
            public bool attack3;
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
            UpdateAttack1Input();
            UpdateAttack2Input();
            UpdateAttack3Input();
            UpdateInteractInput();
            UpdateMenuInput();
        }

        public static void RegisterConsumer(IRegistrable consumer) {
            if(consumer is IPlayerUpInputConsumer) {
                RegisterUpConsumer(consumer);
            }
            if (consumer is IDownInputConsumer) {
                RegisterDownConsumer(consumer);
            }
        }

        #region Up
        public static event Action OnUpInputDown;
        public static event Action OnUpInputUp;

        static void UpdateUpInput() {
            currentState.up = Input.GetKey(KeyCode.W);
            if (Input.GetKeyDown(KeyCode.W)) {
                OnUpInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.W)) {
                OnUpInputUp?.Invoke();
            }
        }
        public static void RegisterUpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterUpConsumer;
            consumer.OnDestroyEvent += UnregisterUpConsumer;

            IPlayerUpInputConsumer UpConsumer = consumer as IPlayerUpInputConsumer;

            OnUpInputDown += UpConsumer.HandleUpInputDown;
            OnUpInputUp += UpConsumer.HandleUpInputUp;
        }
        public static void UnregisterUpConsumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterUpConsumer;
            consumer.OnDestroyEvent -= UnregisterUpConsumer;

            IPlayerUpInputConsumer UpConsumer = consumer as IPlayerUpInputConsumer;
            OnUpInputDown -= UpConsumer.HandleUpInputDown;
            OnUpInputUp -= UpConsumer.HandleUpInputUp;
        }        
        #endregion

        #region Down
        public static event Action OnDownInputDown;
        public static event Action OnDownInputUp;
        static void UpdateDownInput() {
            currentState.down = Input.GetKey(KeyCode.S);
            if (Input.GetKeyDown(KeyCode.S)) {
                OnDownInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.S)) {
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
            currentState.left = Input.GetKey(KeyCode.A);
            if (Input.GetKeyDown(KeyCode.A)) {
                OnLeftInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.A)) {
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
            currentState.right = Input.GetKey(KeyCode.D);
            if (Input.GetKeyDown(KeyCode.D)) {
                OnRightInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.D)) {
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

        #region Attack1
        public static event Action OnAttack1InputDown;
        public static event Action OnAttack1InputUp;
        static void UpdateAttack1Input() {
            currentState.attack1 = Input.GetKey(KeyCode.Alpha1);
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                OnAttack1InputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                OnAttack1InputUp?.Invoke();
            }
        }
        public static void RegisterAttack1Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterAttack1Consumer;
            consumer.OnDestroyEvent += UnregisterAttack1Consumer;

            IAttack1InputConsumer Attack1Consumer = consumer as IAttack1InputConsumer;
            OnAttack1InputDown += Attack1Consumer.HandleAttack1InputDown;
            OnAttack1InputUp += Attack1Consumer.HandleAttack1InputUp;
        }
        public static void UnregisterAttack1Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterAttack1Consumer;
            consumer.OnDestroyEvent -= UnregisterAttack1Consumer;

            IAttack1InputConsumer Attack1Consumer = consumer as IAttack1InputConsumer;
            OnAttack1InputDown -= Attack1Consumer.HandleAttack1InputDown;
            OnAttack1InputUp -= Attack1Consumer.HandleAttack1InputUp;
        }
        public interface IAttack1InputConsumer
        {
            public void HandleAttack1InputDown();
            public void HandleAttack1InputUp();
        }
        #endregion

        #region Attack2
        public static event Action OnAttack2InputDown;
        public static event Action OnAttack2InputUp;
        static void UpdateAttack2Input() {
            currentState.attack2 = Input.GetKey(KeyCode.Alpha2);
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                OnAttack2InputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Alpha2)) {
                OnAttack2InputUp?.Invoke();
            }
        }
        public static void RegisterAttack2Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterAttack2Consumer;
            consumer.OnDestroyEvent += UnregisterAttack2Consumer;

            IAttack2InputConsumer Attack2Consumer = consumer as IAttack2InputConsumer;
            OnAttack2InputDown += Attack2Consumer.HandleAttack2InputDown;
            OnAttack2InputUp += Attack2Consumer.HandleAttack2InputUp;
        }
        public static void UnregisterAttack2Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterAttack2Consumer;
            consumer.OnDestroyEvent -= UnregisterAttack2Consumer;

            IAttack2InputConsumer Attack2Consumer = consumer as IAttack2InputConsumer;
            OnAttack2InputDown -= Attack2Consumer.HandleAttack2InputDown;
            OnAttack2InputUp -= Attack2Consumer.HandleAttack2InputUp;
        }
        public interface IAttack2InputConsumer
        {
            public void HandleAttack2InputDown();
            public void HandleAttack2InputUp();
        }
        #endregion

        #region Attack3
        public static event Action OnAttack3InputDown;
        public static event Action OnAttack3InputUp;
        static void UpdateAttack3Input() {
            currentState.attack3 = Input.GetKey(KeyCode.Alpha3);
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                OnAttack3InputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3)) {
                OnAttack3InputUp?.Invoke();
            }
        }
        public static void RegisterAttack3Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent += UnregisterAttack3Consumer;
            consumer.OnDestroyEvent += UnregisterAttack3Consumer;

            IAttack3InputConsumer Attack3Consumer = consumer as IAttack3InputConsumer;
            OnAttack3InputDown += Attack3Consumer.HandleAttack3InputDown;
            OnAttack3InputUp += Attack3Consumer.HandleAttack3InputUp;
        }
        public static void UnregisterAttack3Consumer(IRegistrable consumer) {
            consumer.OnDisableEvent -= UnregisterAttack3Consumer;
            consumer.OnDestroyEvent -= UnregisterAttack3Consumer;

            IAttack3InputConsumer Attack3Consumer = consumer as IAttack3InputConsumer;
            OnAttack3InputDown -= Attack3Consumer.HandleAttack3InputDown;
            OnAttack3InputUp -= Attack3Consumer.HandleAttack3InputUp;
        }
        public interface IAttack3InputConsumer
        {
            public void HandleAttack3InputDown();
            public void HandleAttack3InputUp();
        }
        #endregion

        #region Interact
        public static event Action OnInteractInputDown;
        public static event Action OnInteractInputUp;
        static void UpdateInteractInput() {
            currentState.interact = Input.GetKey(KeyCode.E);
            if (Input.GetKeyDown(KeyCode.E)) {
                OnInteractInputDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.E)) {
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
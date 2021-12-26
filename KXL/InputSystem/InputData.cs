using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Input
{
    using Input = UnityEngine.Input;

    public class InputData
    {
        public KeyCode Key;

        public event Action OnInputDown;
        public event Action OnInputUp;

        public bool UpdateInput() {
            if (Input.GetKeyDown(Key)) {
                OnInputDown?.Invoke();
            }
            if (Input.GetKeyUp(Key)) {
                OnInputUp?.Invoke();
            }

            return Input.GetKey(Key);
        }

        public void RegisterConsumer(Action inputDownHandle, Action inputUpHandle) {
            OnInputDown += inputDownHandle;
            OnInputUp += inputUpHandle;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace KXL.Core
{
    using DialogSystem;
    using Input;
    using RoomSystem;

    [AddComponentMenu("KXL/Core/MonoBehaviour Hook")]
    public class MonoBehaviourHook : MonoBehaviour
    {
        [BoxGroup("DialogManager")]
        public bool InitDialogManager;
        [BoxGroup("DialogManager")]
        public DialogUI DialogUI;

        [BoxGroup("RoomTrasition")]
        public CanvasGroup ScreenCover;

        private void Awake() {
            GameManager.monoBehaviourHook = this;
            RoomSystem.SetScreenCover(ScreenCover);

            //register events
            InputManager.Setup();

            if (InitDialogManager) {
                DialogManager.SetupDialogUI(DialogUI);
            }
        }

        private void Update() {
            UpdateGroupsManager.OnUpdate();
        }

        private void LateUpdate() {
            UpdateGroupsManager.OnLateUpdate();
        }
    }
}
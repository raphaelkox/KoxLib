using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Core
{
    using Enumerations;
    using GroupsSystem;

    public class UpdateGroup : BaseGroup<UpdateGroupName>
    {
        public event Action OnUpdate;
        public void RaiseUpdate() {
            if (ActiveState) {
                OnUpdate?.Invoke();
            }
        }

        public event Action OnLateUpdate;
        public void RaiseLateUpdate() {
            if (ActiveState) {
                OnLateUpdate?.Invoke();
            }
        }

        public event Action OnFixedUpdate;
        public void RaiseFixedUpdate() {
            if (ActiveState) {
                OnFixedUpdate?.Invoke();
            }
        }
    }
}

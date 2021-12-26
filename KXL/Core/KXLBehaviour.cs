using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Core
{
    using Enumerations;
    using GroupsSystem.Interfaces;
    using Interfaces;

    [AddComponentMenu("KXL/Core/KXL Behaviour")]
    public class KXLBehaviour : MonoBehaviour, IGroupUpdatable, IGroupLateUpdatable, IGroupFixedUpdatable
    {
        [SerializeField] protected bool registerUpdate;
        [SerializeField] protected UpdateGroupName updateGroup;
        [SerializeField] protected bool registerLateUpdate;
        [SerializeField] protected UpdateGroupName lateUpdateGroup;
        [SerializeField] protected bool registerFixedUpdate;
        [SerializeField] protected UpdateGroupName fixedUpdateGroup;

        public event Action<IRegistrable> OnDisableEvent;
        public event Action<IRegistrable> OnDestroyEvent;

        protected virtual void Awake() {
            if (!registerUpdate && !registerLateUpdate && !registerFixedUpdate) {
                Debug.LogWarning($"{gameObject.name}: CustomBehaviour - No update function registered!");
            }
        }

        protected virtual void OnEnable() {
            if (registerUpdate) UpdateGroupsManager.instance.RegisterUpdateConsumer(this, updateGroup);
            if (registerLateUpdate) UpdateGroupsManager.instance.RegisterLateUpdateConsumer(this, lateUpdateGroup);
            if (registerFixedUpdate) UpdateGroupsManager.instance.RegisterFixedUpdateConsumer(this, fixedUpdateGroup);
        }

        protected virtual void OnDisable() {
            if (registerUpdate) UpdateGroupsManager.instance.UnregisterUpdateConsumer(this, updateGroup);
            if (registerLateUpdate) UpdateGroupsManager.instance.UnregisterLateUpdateConsumer(this, lateUpdateGroup);
            if (registerFixedUpdate) UpdateGroupsManager.instance.UnregisterFixedUpdateConsumer(this, fixedUpdateGroup);
            OnDisableEvent?.Invoke(this);
        }

        protected virtual void OnDestroy() {
            OnDestroyEvent?.Invoke(this);
        }

        public void CallUpdate() {
            if (enabled) {
                OnUpdate();
            }
        }

        public virtual void OnUpdate() {

        }

        public void CallLateUpdate() {
            if (enabled) {
                OnLateUpdate();
            }
        }

        public virtual void OnLateUpdate() {

        }

        public void CallFixedUpdate() {
            if (enabled) {
                OnFixedUpdate();
            }
        }

        public virtual void OnFixedUpdate() {

        }
    }
}

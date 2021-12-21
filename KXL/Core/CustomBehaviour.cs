using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Core
{
    using Enumerations;
    using Interfaces;

    [AddComponentMenu("KXL/Core/Custom Behaviour")]
    public class CustomBehaviour : MonoBehaviour, IGroupUpdatable, ILateUpdatable
    {
        [SerializeField] protected bool registerUpdate;
        [SerializeField] protected UpdateGroup updateGroup;
        [SerializeField] protected bool registerLateUpdate;
        [SerializeField] protected UpdateGroup lateUpdateGroup;

        public event Action<IRegistrable> OnDisableEvent;
        public event Action<IRegistrable> OnDestroyEvent;

        protected virtual void Awake() {
            if(!registerUpdate && !registerLateUpdate) {
                Debug.LogWarning($"{gameObject.name}: CustomBehaviour - No update function registered!");
            }
        }

        protected virtual void Start() {
            if (registerUpdate) UpdateGroupsManager.RegisterUpdateConsumer(this, updateGroup);
            if (registerLateUpdate) UpdateGroupsManager.RegisterLateUpdateConsumer(this, lateUpdateGroup);
        }

        protected virtual void OnEnable() {
            if (registerUpdate) UpdateGroupsManager.RegisterUpdateConsumer(this, updateGroup);
            if (registerLateUpdate) UpdateGroupsManager.RegisterLateUpdateConsumer(this, lateUpdateGroup);
        }

        protected virtual void OnDisable() {
            if (registerUpdate) UpdateGroupsManager.UnregisterUpdateConsumer(this, updateGroup);
            if (registerLateUpdate) UpdateGroupsManager.UnregisterLateUpdateConsumer(this, lateUpdateGroup);
            OnDisableEvent?.Invoke(this);
        }

        protected virtual void OnDestroy() {
            OnDestroyEvent?.Invoke(this);
        }

        public virtual void OnUpdate() {

        }

        public virtual void OnLateUpdate() {

        }
    }
}

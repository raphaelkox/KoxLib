using System;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Core
{
    using Interfaces;
    using Enumerations;
    using GroupsSystem;
    using ScriptableObjects;

    public class UpdateGroupsManager : GroupManager<UpdateGroupName, UpdateGroupDataSO>
    {
        public static UpdateGroupsManager instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void New() {
            Debug.Log("Update Groups Manager Created!");

            instance = new UpdateGroupsManager();
            instance.Init();
        }

        public override BaseGroup<UpdateGroupName> CreateGroup(UpdateGroupName groupName, bool state) {
            return new UpdateGroup() {
                ActiveState = state,
                NextActiveState = state,
                GroupName = groupName
            };
        }

        #region UPDATE
        public void OnUpdate() {
            foreach (var updateGroup in Groups) {
                var group = updateGroup.Value as UpdateGroup;
                group.RaiseUpdate();
            }
        }

        public void RegisterUpdateConsumer(IUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnUpdate += consumer.OnUpdate;
        }

        public void UnregisterUpdateConsumer(IUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnUpdate -= consumer.OnUpdate;
        }
        #endregion

        #region LATE UPDATE
        public void OnLateUpdate() {
            foreach (var updateGroup in Groups) {
                var group = updateGroup.Value as UpdateGroup;
                group.RaiseLateUpdate();
                group.UpdateActiveState();
            }
        }

        public void RegisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnLateUpdate += consumer.OnLateUpdate;
        }

        public void UnregisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnLateUpdate -= consumer.OnLateUpdate;
        }
        #endregion

        #region FIXED UPDATE
        public void OnFixedUpdate() {
            foreach (var updateGroup in Groups) {
                var group = updateGroup.Value as UpdateGroup;
                group.RaiseFixedUpdate();
            }
        }

        public void RegisterFixedUpdateConsumer(IFixedUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnFixedUpdate += consumer.OnFixedUpdate;
        }

        public void UnregisterFixedUpdateConsumer(IFixedUpdatable consumer, UpdateGroupName groupName) {
            var group = Groups[groupName] as UpdateGroup;
            group.OnFixedUpdate -= consumer.OnFixedUpdate;
        }
        #endregion
    }
}
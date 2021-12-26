using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem
{
    using ScriptableObjects;

    public class GroupManager<TName, TData>
        where TName : Enum 
        where TData : GroupDataSO<TName>
    { 
        public Dictionary<TName, BaseGroup<TName>> Groups = new Dictionary<TName, BaseGroup<TName>>();        

        public virtual void Init() {
            Debug.Log($"Group Manager for: {typeof(TName).ToString().Replace("Name", "s")} init!");

            var filename = typeof(TData).Name;
            var startingStates = Resources.Load<TData>(filename);

            foreach (TName groupName in Enum.GetValues(typeof(TName))) {
                if (startingStates && startingStates.Groups.ContainsKey(groupName)) {
                    Groups.Add(groupName, CreateGroup(groupName, startingStates.Groups[groupName]));
                }
                else {
                    Groups.Add(groupName, CreateGroup(groupName, false));
                }
            }
        }

        public bool IsGroupActive(TName group) {
            return Groups[group].ActiveState;
        }
        public void SetGroupState(TName group, bool state) {
            Groups[group].NextActiveState = state;
        }

        public virtual BaseGroup<TName> CreateGroup(TName groupName ,bool state) {
            return new BaseGroup<TName>() {
                ActiveState = state,
                NextActiveState = state
            };
        }
    }
}
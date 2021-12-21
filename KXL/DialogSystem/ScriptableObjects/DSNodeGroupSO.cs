using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.ScriptableObjects
{
    public class DSNodeGroupSO : ScriptableObject
    {
        [field: SerializeField] public string GroupName { get; set; }

        public void Initialize(string groupName) {
            GroupName = groupName;
        }
    }    
}

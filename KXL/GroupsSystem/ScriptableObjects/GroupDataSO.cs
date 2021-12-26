using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem.ScriptableObjects {
    using Utilities;

    public class GroupDataSO<TName> : ScriptableObject
    {
        public SerializableDictionary<TName, bool> Groups = new SerializableDictionary<TName, bool>();
    }
}

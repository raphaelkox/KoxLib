using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Dictionaries
{
    using Utilities;
    using ScriptableObjects;

    [Serializable] public class GroupDictionary : SerializableDictionary<DSNodeGroupSO, List<DSNodeSO>> { }
}

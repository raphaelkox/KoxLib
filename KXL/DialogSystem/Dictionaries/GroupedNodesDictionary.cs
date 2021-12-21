using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Dictionaries
{
    using Utilities;

    [Serializable]
    public class GroupedNodesDictionary : SerializableDictionary<string, List<string>>
    {
        public GroupedNodesDictionary() { }
        public GroupedNodesDictionary(GroupedNodesDictionary values) {
            foreach (KeyValuePair<string, List<string>> value in values) {
                Add(value);
            }
        }
    }
}

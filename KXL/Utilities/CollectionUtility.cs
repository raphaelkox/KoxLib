using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Utilities
{
    using DialogSystem.Dictionaries;
    using DialogSystem.ScriptableObjects;

    public static class CollectionUtility
    {
        public static void AddItem<K, V>(this SerializableDictionary<K, List<V>> serializableDictionary, K key, V value) {
            if (serializableDictionary.ContainsKey(key)) {
                serializableDictionary[key].Add(value);
                return;
            }

            serializableDictionary.Add(key, new List<V>() { value });
        }

        public static void AddItem(this GroupedNodesDictionary serializableDictionary, string key, string value) {
            if (serializableDictionary.ContainsKey(key)) {
                serializableDictionary[key].Add(value);
                return;
            }

            serializableDictionary.Add(key, new List<string>() { value });
        }

        public static void AddItem(this GroupDictionary serializableDictionary, DSNodeGroupSO key, DSNodeSO value) {
            if (serializableDictionary.ContainsKey(key)) {
                serializableDictionary[key].Add(value);
                return;
            }

            serializableDictionary.Add(key, new List<DSNodeSO>() { value });
        }
    }
}

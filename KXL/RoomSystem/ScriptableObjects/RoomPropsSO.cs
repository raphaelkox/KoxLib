using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace KXL.RoomSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "roomprops", menuName = "Room System/Room Props")]
    public class RoomPropsSO : ScriptableObject
    {
        [Scene, SerializeField] public string TargetScene;
        [field: SerializeField] public List<string> Portals = new List<string>();
    }
}
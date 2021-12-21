using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace KXL.RoomSystem
{
    using ScriptableObjects;

    [AddComponentMenu("KXL/Room System/Room Portal")]
    public class RoomPortal : MonoBehaviour
    {
        [SerializeField] RoomPropsSO TargetRoom;
        [Dropdown("SpawnPointValues")] public string TargetSpawnPoint;

        private List<string> SpawnPointValues {
            get
            {
                if (!TargetRoom) {
                    return new List<string>() { "INVALID" };
                }

                return TargetRoom.Portals;
            }
        }

        public void Warp() {
            RoomSystem.Warp(TargetRoom.TargetScene, TargetSpawnPoint);
        }
    }
}
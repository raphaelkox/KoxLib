using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using DG.Tweening;

namespace KXL.RoomSystem
{
    using Core;
    using Core.Enumerations;
    using Dictionaries;
    using ScriptableObjects;

    [AddComponentMenu("KXL/Room System/Room Properties")]
    public class RoomProperties : MonoBehaviour
    {
        [SerializeField] GameObject playerPrefab;
        [SerializeField] RoomPortalDictionary RoomPortals = new RoomPortalDictionary();
        [SerializeField] RoomPropsSO RoomData;

        private void Start() {
            Instantiate(playerPrefab, GetPlayerSpawnPosition(), Quaternion.identity);
            RoomSystem.SetScreenFade(1f);
            RoomSystem.FadeInScreen(() => {
                UpdateGroupsManager.instance.SetGroupState(UpdateGroupName.Player, true);
                UpdateGroupsManager.instance.SetGroupState(UpdateGroupName.World, true);
            });
        }

        Vector3 GetPlayerSpawnPosition() {
            Vector3 pos;
            string first;

            if (RoomSystem.NextRoomSpawn == null || RoomSystem.NextRoomSpawn == "") {
                Debug.Log("No spawn set, defaulting to First on the list");
                first = new List<string>(RoomPortals.Keys)[0];
                return pos = RoomPortals[first].position;
            }

            if (RoomPortals.ContainsKey(RoomSystem.NextRoomSpawn)) {
                return pos = RoomPortals[RoomSystem.NextRoomSpawn].position;
            }

            if (RoomPortals.Keys.Count > 0) {
                Debug.LogWarning("Invalid spawn set, defaulting to First on the list");
                var keys = new List<string>(RoomPortals.Keys);
                first = keys[0];
                return pos = RoomPortals[first].position;
            }

            Debug.LogError("No spawnpoint located");
            Debug.Break();
            return Vector3.zero;
        }

        private void OnValidate() {
            if (Application.isPlaying) return;
            if (RoomPortals.Count > 0) return;
            if (!RoomData) return;

            foreach (string spawnName in RoomData.Portals) {
                RoomPortals.Add(spawnName, null);
            }
        }

        [Button("Refresh")]
        private void RefreshSpawnPointList() {
            if (!RoomData) {
                RoomPortals = new RoomPortalDictionary();
                return;
            }

            foreach (string spawnName in RoomData.Portals) {
                RoomPortals.Add(spawnName, null);
            }
        }
    }
}
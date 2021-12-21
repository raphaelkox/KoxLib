using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.ScriptableObjects
{
    using Dictionaries;
    using Enumerations;

    public class DSDialogContainerSO : ScriptableObject
    {
        [field: SerializeField] public string FileName { get; set; }
        [field: SerializeField] public GroupDictionary NodeGroups { get; set; }
        [field: SerializeField] public List<DSNodeSO> UngroupedNodes { get; set; }

        public void Initialize(string fileName) {
            FileName = fileName;

            NodeGroups = new GroupDictionary();
            UngroupedNodes = new List<DSNodeSO>();
        }

        public List<string> GetNodeGroupNames() {
            List<string> dialogGroupNames = new List<string>();

            foreach (DSNodeGroupSO dialogGroup in NodeGroups.Keys) {
                dialogGroupNames.Add(dialogGroup.GroupName);
            }

            return dialogGroupNames;
        }

        public List<string> GetGroupedNodesNames(DSNodeGroupSO dialogGroup, bool startingNodesOnly) {
            List<DSNodeSO> groupedNodes = NodeGroups[dialogGroup];

            List<string> groupedNodeNames = new List<string>();

            foreach (DSNodeSO groupedNode in groupedNodes) {
                if (startingNodesOnly && !groupedNode.IsStartingNode) {
                    continue;
                }

                groupedNodeNames.Add(groupedNode.NodeName);
            }

            return groupedNodeNames;
        }

        public List<string> GetUngroupedNodesNames(bool startingNodesOnly) {

            List<string> ungroupedNodeNames = new List<string>();

            foreach (DSNodeSO ungroupedNode in UngroupedNodes) {
                if (startingNodesOnly && !ungroupedNode.IsStartingNode) {
                    continue;
                }

                ungroupedNodeNames.Add(ungroupedNode.NodeName);
            }

            return ungroupedNodeNames;
        }
    }
}

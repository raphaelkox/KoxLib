using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem
{
    using Enumerations;
    using ScriptableObjects;

    [AddComponentMenu("KXL/Dialog System/Node Selector")]
    public class DSNodeSelector : MonoBehaviour
    {
        public LayerMask mask;

        /* Dialog Scriptable Object */
        [SerializeField] DSDialogContainerSO dialogContainer;
        [SerializeField] DSNodeGroupSO nodeGroup;
        [SerializeField] DSNodeSO node;

        /* Filters */
        [SerializeField] bool groupedNodes;
        [SerializeField] bool startingNodesOnly;
        [SerializeField] bool bySpeaker;

        /* Indexes */
        [SerializeField] int selectedNodeGroupIndex;
        [SerializeField] int selectedNodeIndex;
        [SerializeField] DSSpeakerName selectedSpeaker;

        public DSNodeSO GetStartNode() {
            return node;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.ScriptableObjects
{
    using Data;
    using DialogSystem.Data.Events;
    using Enumerations;

    public class DSNodeSO : ScriptableObject
    {
        [field: SerializeField] public string NodeName { get; set; }        
        [field: SerializeField] public List<DSNodeOutputData> Outputs { get; set; }
        [field: SerializeField] [field: SerializeReference] public List<DSEventData> Events { get; set; }
        [field: SerializeField] public DSNodeType NodeType { get; set; }
        [field: SerializeField] public bool IsStartingNode { get; set; }
        [field: SerializeField] public bool IsLastNode { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Data
{
    using ScriptableObjects;

    [Serializable]
    public class DSNodeOutputData
    {
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public DSNodeSO NextNode { get; set; }
    }
}

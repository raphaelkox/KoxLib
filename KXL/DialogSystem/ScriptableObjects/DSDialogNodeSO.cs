using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.ScriptableObjects
{
    using Data;
    using DialogSystem.Data.Events;
    using Enumerations;

    public class DSDialogNodeSO : DSNodeSO
    {
        [field: SerializeField] public DSSpeakerName Speaker { get; set; }
        [field: SerializeField] [field: TextArea()] public string Text { get; set; }
    }
}
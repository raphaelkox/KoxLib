using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Data
{
    using Enumerations;

    [Serializable]
    public class DSDialogData
    {
        [field: SerializeField] public DSSpeakerName Speaker { get; set; }
        [field: SerializeField] public string Text { get; set; }        
    }
}

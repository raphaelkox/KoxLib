using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Data.Events
{
    using KXL.DialogSystem.Enumerations;

    [Serializable]
    public class DSEventData
    {
        [field: SerializeField] public DSEventType EventType { get; set; }
    
        public virtual void Execute() { }
    }
}
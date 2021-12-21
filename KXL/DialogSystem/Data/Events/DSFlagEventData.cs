using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem.Data.Events
{
    using KXL.GameState;
    using KXL.GameState.Enumerations;

    [Serializable]
    public class DSFlagEventData : DSEventData
    {
        [field: SerializeField] public FlagName FlagName { get; set; }
        [field: SerializeField] public FlagOperation FlagOperation { get; set; }
        [field: SerializeField] public bool FlagValue { get; set; }

        public override void Execute() {
            switch (FlagOperation) {
                case FlagOperation.Set:
                    Flags.SetFlagValue(FlagName, FlagValue);
                    break;
                case FlagOperation.Toggle:
                    Flags.ToggleFlag(FlagName);
                    break;
            }
        }
    }
}

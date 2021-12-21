using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GameState
{
    using Enumerations;

    public static class Flags
    {
        public static event Action<FlagName> OnFlagSet;
        public static event Action<FlagName> OnFlagUnset;
        public static event Action<FlagName, bool> OnFlagChange;

        static Dictionary<FlagName, bool> FlagStates = new Dictionary<FlagName, bool>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void SetupFlags() {
            foreach (FlagName flagName in Enum.GetValues(typeof(FlagName))) {
                FlagStates.Add(flagName, false);
            }
        }

        public static bool IsFlagSet(FlagName flag) {
            return FlagStates[flag];
        }

        public static void SetFlag(FlagName flag) {
            if (FlagStates.ContainsKey(flag)) {
                FlagStates[flag] = true;
                OnFlagSet?.Invoke(flag);
                OnFlagChange?.Invoke(flag, true);
            }
        }

        public static void UnsetFlag(FlagName flag) {
            if (FlagStates.ContainsKey(flag)) {
                FlagStates[flag] = false;
                OnFlagUnset?.Invoke(flag);
                OnFlagChange?.Invoke(flag, false);
            }
        }

        public static void ToggleFlag(FlagName flag) {
            if (FlagStates.ContainsKey(flag)) {
                if (FlagStates[flag]) {
                    UnsetFlag(flag);
                }
                else {
                    SetFlag(flag);
                }
            }
        }

        public static void SetFlagValue(FlagName flag, bool value) {
            if (FlagStates.ContainsKey(flag)) {
                if (value) {
                    SetFlag(flag);
                }
                else {
                    UnsetFlag(flag);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.DialogSystem
{
    using ScriptableObjects;

    [AddComponentMenu("KXL/Dialog System/Dialog Event")]
    public class DialogEvent : MonoBehaviour
    {
        [SerializeField] DSNodeSelector DialogData;

        public void StartDialogEvent() {
            DSNodeSO dialog = DialogData.GetStartNode();

            DialogManager.StartDialog(dialog, true, true);
        }
    }
}
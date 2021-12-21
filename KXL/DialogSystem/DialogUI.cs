using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KXL.DialogSystem
{
    using Enumerations;
    using ScriptableObjects;
    using System.Linq;
    using UI;

    [AddComponentMenu("KXL/Dialog System/Dialog UI")]
    public class DialogUI : MonoBehaviour
    {
        [field: SerializeField] public UIMultiPageTextBox DialogBox { get; set; }
        [field: SerializeField] public UITextBox SpeakerBox { get; set; }
        [field: SerializeField] public UIList ResponseBox { get; set; }
        [field: SerializeField] public UIVerticalCursor ResponseCursor { get; set; }

        public void ShowDialog(DSDialogNodeSO dialogData) {
            DialogBox.SetText(dialogData.Text);
            DialogBox.SetPage(1);
            SpeakerBox.SetText(dialogData.Speaker.ToString());

            DialogBox.Show();
            if (dialogData.Speaker != DSSpeakerName.None) {
                SpeakerBox.Show();
            }
            else {
                SpeakerBox.Hide();
            }
        }        

        public void ShowResponseOptions(DSDialogNodeSO dialogData) {
            ResponseBox.Clear();

            List<string> options = dialogData.Outputs.Select(output => output.Text).ToList();
            foreach (string option in options) {
                var optionElement = ResponseBox.AddItem();
                optionElement.GetComponent<UITextBox>().SetText(option);
            }

            ResponseCursor.optionCount = options.Count - 1;
            ResponseCursor.Reset();

            ResponseBox.Show();
        }
    }
}
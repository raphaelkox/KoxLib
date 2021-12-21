using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/TextBox")]
    public class UITextBox : UIElement
    {
        [field: SerializeField] public TextMeshProUGUI TextObj { get; set; }

        public virtual void SetText(string text) {
            TextObj.text = text;
        }

        public string GetText() {
            return TextObj.text;
        }
    }
}

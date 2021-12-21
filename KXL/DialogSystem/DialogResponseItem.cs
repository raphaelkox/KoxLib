using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KXL.DialogSystem
{
    [AddComponentMenu("KXL/Dialog System/Dialog Response Item")]
    public class DialogResponseItem : MonoBehaviour
    {
        [field: SerializeField]public TextMeshProUGUI TextObj { get; set; }

        public void SetResponseText(string text) {
            TextObj.text = text;
        }
    }
}

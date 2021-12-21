using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KXL.UI
{
    public class UIBar : MonoBehaviour
    {
        [field: SerializeField] public Image BarObj { get; set; }
        [field: SerializeField] public float FullValue { get; set; }
        [field: SerializeField] public float CurrentValue { get; set; }

        protected virtual void Start() {
            BarObj.type = Image.Type.Filled;
        }

        public void SetValue(float value) {
            CurrentValue = value;
            BarObj.fillAmount = CurrentValue / FullValue;
        }
    }
}

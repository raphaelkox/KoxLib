using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    public abstract class UICursor : MonoBehaviour
    {
        [field: SerializeField] public float paddingStart { get; set; }
        [field: SerializeField] public float optionSize { get; set; }
        [field: SerializeField] public float spacingSize { get; set; }
        [field: SerializeField] public bool wrapAround { get; set; }
        [field: SerializeField] public int optionCount { get; set; }
        [field: SerializeField] public int currentOption { get; private set; }

        protected RectTransform rectTransform;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        public void NextOption() {
            currentOption++;

            if(currentOption > optionCount) {
                currentOption = wrapAround ? 0 : optionCount;
            }

            UpdatePosition();
        }

        public void PreviousOption() {
            currentOption--;

            if (currentOption < 0) {
                currentOption = wrapAround ? optionCount : 0;
            }

            UpdatePosition();
        }

        protected virtual void UpdatePosition() {

        }

        public void Reset() {
            currentOption = 0;
            UpdatePosition();
        }
    }
}

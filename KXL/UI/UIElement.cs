using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KXL.UI
{
    using Interfaces;

    [AddComponentMenu("KXL/UI/Element")]
    public class UIElement : MonoBehaviour, IContentFitEventProvider
    {
        [field: SerializeField] public CanvasGroup canvas { get; set; }

        public event Action<Vector2> OnContentSizeDeltaChanged;

        public void Show() {
            canvas.alpha = 1f;
        }

        public void Hide() {
            canvas.alpha = 0f;
        }

        public bool Visible() {
            return canvas.alpha > 0f;
        }

        //events
        protected void RaiseOnContentSizeDeltaChangedEvent(Vector2 sizeDelta) {
            OnContentSizeDeltaChanged?.Invoke(sizeDelta);
        }
    }
}

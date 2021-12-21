using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    using Interfaces;
    using UnityEngine.UI;

    [AddComponentMenu("KXL/UI/Content Scale Fit")]
    public class UIContentScaleFit : MonoBehaviour
    {
        [field: SerializeField] public bool FitHorizontal;
        [field: SerializeField] public bool FitVertical;

        [field: SerializeField] Component TargetContentContainer { get; set; }
        [field: SerializeField] public IContentFitEventProvider targetContent { get; set; }

        RectTransform rectTransform;

        private void OnValidate() {
            if (Application.isEditor) {
                IContentFitEventProvider contentProvider;
                if (TargetContentContainer.TryGetComponent(out contentProvider)) {
                    targetContent = contentProvider;
                }
                else {
                    Debug.LogWarning("TargetContentContainer does not have a Content Fit Event Provider");
                    TargetContentContainer = null;
                }
            }
        }

        private void Start() {
            rectTransform = GetComponent<RectTransform>();
            targetContent.OnContentSizeDeltaChanged += FitContent;
        }

        public void FitContent(Vector2 sizeDelta) {
            Debug.Log("SizeDelta Change detected");

            var sizeX = rectTransform.sizeDelta.x;
            var sizeY = rectTransform.sizeDelta.y;

            if (FitHorizontal) {
                sizeX = sizeDelta.x;
            }

            if (FitVertical) {
                sizeY = sizeDelta.y;
            }

            rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
        }
    }
}
